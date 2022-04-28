using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject MenuImage;
    public GameObject sRacun;
    public List<GameObject> plusButton = new List<GameObject>();
    public Text apPlusText;
    public Text apPlusText2;
    public Text apPlusText3;
    public Text apPlusText4;
    public Text apPlusText5;

    private int Changeap;
    //private int finalPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        apPlusText.text = GameManager.Instance.getBaby1().ToString();
        apPlusText2.text = GameManager.Instance.getBaby2().ToString();
        apPlusText3.text = GameManager.Instance.getBaby3().ToString();
        apPlusText4.text = GameManager.Instance.getBaby4().ToString();
        apPlusText5.text = GameManager.Instance.getBaby5().ToString();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Renew()
    {
        //pauseMenuUI.SetActive(false);
        MenuImage.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        calculateFinalPoints();
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        MenuImage.SetActive(true);
    }
    public void ChangeApPlus(){
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();
        //plusButton.SetActive(true);
        int apple = pc.GetAppleCount();
        Debug.Log("apple num from player: " + apple);
        if (apple > 0) {
            pc.ChangeAppleCount(-1);
            GameManager.Instance.addBaby1();
            apPlusText.text = GameManager.Instance.getBaby1().ToString();
        }


    }
    public void ChangeApPlus02(){
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();
        //plusButton.SetActive(true);
        int apple = pc.GetAppleCount();
        Debug.Log("apple num from player: " + apple);
        if (apple > 0) {
            pc.ChangeAppleCount(-1);
            GameManager.Instance.addBaby2();
            apPlusText2.text = GameManager.Instance.getBaby2().ToString();
            //Debug.Log(apPlusCount);
        }
    }

    public void ChangeApPlus03(){
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();
        //plusButton.SetActive(true);
        int apple = pc.GetAppleCount();
        Debug.Log("apple num from player: " + apple);
        if (apple > 0) {
            pc.ChangeAppleCount(-1);
            // apPlusCount3 += 1;
            GameManager.Instance.addBaby3();
            apPlusText3.text = GameManager.Instance.getBaby3().ToString();
            //Debug.Log(apPlusCount);
        }
    }

    public void ChangeApPlus04(){
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();
        //plusButton.SetActive(true);
        int apple = pc.GetAppleCount();
        Debug.Log("apple num from player: " + apple);
        if (apple > 0) {
            pc.ChangeAppleCount(-1);
            GameManager.Instance.addBaby4();
            apPlusText4.text = GameManager.Instance.getBaby4().ToString();
            //Debug.Log(apPlusCount);
        }
    }

    public void ChangeApPlus05(){
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();
        //plusButton.SetActive(true);
        int apple = pc.GetAppleCount();
        Debug.Log("apple num from player: " + apple);
        if (apple > 0) {
            pc.ChangeAppleCount(-1);
            GameManager.Instance.addBaby5();
            apPlusText5.text = GameManager.Instance.getBaby5().ToString();
            //Debug.Log(apPlusCount);
        }
    }

    // By Luofei Shi: Calculate the final points based on the points of each baby raccoon
    public void calculateFinalPoints()
    {
        // random factor from 5 to 15
        int finalPoint = 0;
        finalPoint += (int) GameManager.Instance.getBaby1() * Random.Range(5, 15);
        finalPoint += (int) GameManager.Instance.getBaby2() * Random.Range(5, 15);
        finalPoint += (int) GameManager.Instance.getBaby3() * Random.Range(5, 15);
        finalPoint += (int) GameManager.Instance.getBaby4() * Random.Range(5, 15);
        finalPoint += (int) GameManager.Instance.getBaby5() * Random.Range(5, 15);
        Debug.Log(GameManager.Instance.GetKillsAmount());
        finalPoint += (int) GameManager.Instance.GetKillsAmount() * Random.Range(5, 15);
        Debug.Log("point"+finalPoint);
        // FinalPoints.instance.SetFinalPoints(finalPoint);
        UImanager.instance.UpdatePoints(finalPoint);
    }

}
