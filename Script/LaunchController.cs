using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    public AudioClip hitClip;
    //private Vector2 lookDirection = new Vector2(1, 0);
    // public float speed = 5f;
    // private Vector3 statrPos;
    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
        
    }

    // Update is called once per frame
    void Start()
    {
        //statrPos = transform.position;
        anim = GetComponent<Animator>();

    }
    void FixedUpdate()
    {

    }


    public void Move(Vector2 moveDirection,float moveForce)
    // public void Move()
    {
        // rbody.velocity = rbody.position * speed;
        // float distance = (transform.position - statrPos).sqrMagnitude;
        rbody.AddForce(moveDirection * moveForce);

        // anim.SetFloat("x", moveDirection.x);
        // anim.SetFloat("y", moveDirection.y);
        // Debug.Log("movex" + moveDirection.x);
        // Debug.Log("movey" + moveDirection.y);
    }

    ///��ײ���
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController ec = other.gameObject.GetComponent<EnemyController>();
        if(ec != null)
        {
            ec.kill();//�޸�����
        }
        //AudioManager.instance.AudioPlayer(hitClip);//����������Ч

        Destroy(this.gameObject);
    }    
}
