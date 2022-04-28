using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    [SerializeField] float moveSpeed = 3f;

    private int maxHealth = 50;
    private int currentHealth;
    private int curAppleCount;

    private float totalTime;
    private float curTime = 30;

    private int kills;

    private float fireTime = 0f;

    public GameObject GameoverImage;
    public GameObject pauseMenuUI;
 
    new Rigidbody2D rigidbody;
    Animator anim;
    public AudioClip moveClip;

    public int MyMaxHealth { get { return maxHealth; } }

    public int MyCurrentHealth { get { return currentHealth; } }
    
    public List<GameObject> Launchs = new List<GameObject>();
    //public GameObject Launch;
    private int LaunchsCount;
    private Vector2 lookDirection = Vector2.zero;

    void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
    }

    void OnEnable()
    {
        input.onMove += Move;
        input.onStopMove += StopMove;
        input.onFire += Fire;
        input.onStopFire += StopFire;
    }
    void OnDisable() 
    {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
        input.onFire -= Fire;
        input.onStopFire -= StopFire;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadScene();
        Debug.Log("apple:" + curAppleCount);
        Debug.Log("time:" + curTime);
        Debug.Log("kills:" + kills);

        rigidbody.gravityScale = 0f;
        // currentHealth = 50;      
        LaunchsCount = Launchs.Count;
        input.EnablePlayerInput();
        
        UImanager.instance.UpdateAppleCount(curAppleCount);
        UImanager.instance.UpdateHealthBar(currentHealth,maxHealth);  
        UImanager.instance.UpdateTimer((int)curTime);
        UImanager.instance.UpdateMasterCount(kills);
    }

    void FixedUpdate()
    {
        totalTime += Time.deltaTime;
        //rigidbody.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if(totalTime >= 1)
        {
            ChangeTimer(-1);
            totalTime = 0;

        } 
        if(curTime == 0 || currentHealth == 0)
        {
            GameoverImage.SetActive(true);
            pauseMenuUI.SetActive(false);
        }
        fireTime -= Time.deltaTime;

    }
    public void Fire(){
        if (fireTime < 0f) {
            int aRandomLau = Random.Range(0, LaunchsCount);
            GameObject Launch = Launchs[aRandomLau];
            GameObject Lau = Instantiate(Launch, rigidbody.position, Quaternion.identity);
            LaunchController lc = Lau.GetComponent<LaunchController>();
            if (lc != null)
            {

                //Debug.Log("look" + lookDirection);
                lc.Move(lookDirection, 300);
                //lc.updateDirection(lookDirection);
            }
            fireTime = 1f;   
        }

    }

    void StopFire()
    {
        
    }
 

    void Move(Vector2 moveInput)
    {
        //Vector2 moveAmount = moveInput * moveSpeed;
        rigidbody.velocity = moveInput * moveSpeed;
        float moveX = moveInput.x;
        float moveY = moveInput.y; 
        // Vector2 moveVector = new Vector2(moveX, moveY);
        // if(moveVector.x != 0 || moveVector.y != 0)
        // {
        //     lookDirection = moveVector;
        // }
        anim.SetFloat("moveX", moveInput.x);
        anim.SetFloat("moveY", moveInput.y);
        switchAnim();
        AudioManager.instance.AudioPlayer(moveClip);
        lookDirection = moveInput;
    }

    void StopMove()
    {
        rigidbody.velocity  = Vector2.zero;
        
        switchAnim();
    }
    void switchAnim()
    {
        
        anim.SetFloat("Speed",rigidbody.velocity.magnitude);
    }

    public void ChangeHealth(int amount)
    {
        
        // Debug.Log(currentHealth + "/" + maxHealth);
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UImanager.instance.UpdateHealthBar(currentHealth, maxHealth);//调用UImanager，更新血条

        // Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void ChangeAppleCount(int amount)
    {
        curAppleCount = Mathf.Clamp(curAppleCount + amount, 0, 99);
        UImanager.instance.UpdateAppleCount(curAppleCount);

    }

    public int GetAppleCount()
    {
        int res = curAppleCount;
        return res;
    }

    public void ChangeTimer(int amount)
    {
        //maxTime -= Time.deltaTime;
        curTime = Mathf.Clamp(curTime + amount, 0, 120);
        ChangeHealth(-1);
        UImanager.instance.UpdateTimer((int)curTime);

    }

    public void UpdateKills()
    {
        kills++;
        UImanager.instance.UpdateMasterCount(kills);
        // update final score
        GameManager.Instance.AddKillsAmount();
        curTime += 3;
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().calculateFinalPoints();
    }

    public void UpdateScene()
    {
        // send data to game manager
        Debug.Log("Player UpdateScene");
        GameManager.Instance.StorePlayerData(currentHealth, curAppleCount, kills, curTime);
    }

    public void LoadScene()
    {
        this.currentHealth = GameManager.Instance.GetHealth();
        this.curAppleCount = GameManager.Instance.GetAppleAmount();
        this.kills = GameManager.Instance.GetKillsAmount();
        this.curTime = GameManager.Instance.GetRemainTime();
    }
}
