using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform player;			// main character
	private Rigidbody2D myRigidbody; 	//rigidbody
	private Vector2 afterPosition;		//move position
	private BoxCollider2D myCollider; 	//collider
	private Animator myAnimator;		//controller
    public AudioClip killedClip;
	public float moveSpeed = 0.5f; 		//movement speed
	public int power = 10;				//enemy attack power
    private int maxHp = 4;
    private int killed;
    public float radius;

    public float changeDirectionTime = 4f;
    private Vector2 moveDirection;
    public bool isVertical;

    private float moveTimer= 3f;

    private float changeTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
		myRigidbody = GetComponent<Rigidbody2D> ();
		afterPosition = transform.position;
		myCollider = GetComponent<BoxCollider2D> ();
		myAnimator = GetComponent<Animator> ();
        //changeTimer = changeDirectionTime;
        //moveDirection = isVertical ? Vector2.up : Vector2.right;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        myRigidbody.MovePosition (Vector2.Lerp (transform.position,afterPosition , moveSpeed * Time.deltaTime));
        if(moveTimer < 0)
        {
            Move();
            moveTimer= 40f;
        }
        moveTimer--;
        myAnimator.SetFloat("x", afterPosition.x);
        

    }
    // void FixedUpdate()
    // {
    //     myRigidbody.GetComponent<Rigidbody>().velocity = Vector3.zero;
    // }

        
    //     changeTimer -= Time.deltaTime;
    //     if(changeTimer < 0)
    //     {
    //         moveDirection *= -1;
    //         changeTimer = changeDirectionTime;
    //     }

    //     Vector2 position = myRigidbody.position;
    //     position.x += moveDirection.x * moveSpeed * Time.deltaTime;
    //     position.y += moveDirection.y * moveSpeed * Time.deltaTime;
    //     myRigidbody.MovePosition(position);
    //     myAnimator.SetFloat("x", moveDirection.x);

    // }
    public void Move(){
		Vector2 offset = player.position - transform.position;
        

        int x = 0, y = 0;
        if (Mathf.Abs (offset.x) > Mathf.Abs (offset.y)) {
            if (offset.x > 0) {
                x = 1;
            } else {
                x = -1;
            }
        } else {
            if (offset.y > 0) {
                y = 1;
            } else {
                y = -1;
            }
        }
        myCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast (afterPosition, afterPosition + new Vector2 (x, y));
        myCollider.enabled = true;
        if (hit.transform == null) 
        {
            afterPosition += new Vector2 (x, y);
        } 
        else 
        {
            if (hit.transform.tag == "Food" )
            {
                afterPosition += new Vector2 (x, y);
            }
        myAnimator.SetFloat("x", afterPosition.x);
		}
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        Player pc = other.gameObject.GetComponent<Player>();
        if(pc != null)
        {
            pc.ChangeHealth(-1);
            //myAnimator.SetBool("Hit",true);
        }

    }
    public void kill()
    {     
        maxHp -= 1;
        if(maxHp <= 0)
        {
            Destroy(this.gameObject);
            GameObject player = GameObject.FindGameObjectWithTag ("Player");
            var pc = player.GetComponent<Player>();
            pc.UpdateKills();
        }
        AudioManager.instance.AudioPlayer(killedClip);//

    }
}
