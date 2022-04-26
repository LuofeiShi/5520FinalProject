using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public static GameManager _Instance;
	public static GameManager Instance
    {
		get {
			return _Instance;
		}
	}
	
    private int maxHealth = 50;
    private int currentHealth = 50;
    private int curAppleCount = 0;
	private Text appleCountText;
	public GameObject GameoverImage;

	private Player player;
	private float curTime = 60;

	private int killsAmount = 0;

	private int apPlusCount = 0;
    private int apPlusCount2 = 0;
    private int apPlusCount3 = 0;
    private int apPlusCount4 = 0;
    private int apPlusCount5 = 0;


	void Awake(){
		_Instance = this;
		DontDestroyOnLoad (this.gameObject);

	}

	public void initGame(){}

	public void StorePlayerData(int hp, int apple, int kills, float timer)
	{
		Debug.Log("hp: " + hp);
		Debug.Log("apple: " + apple);
		Debug.Log("kills: " + kills);
		Debug.Log("timer: " + timer);
		// hp
		currentHealth = hp;
		// apple
		curAppleCount = apple;
		// kills
		killsAmount = kills;
		// timer
		curTime = timer;
		Debug.Log("Exit store player data");
	}

	public int GetHealth()
	{
		return currentHealth;
	}

	public int GetAppleAmount()
	{
		return curAppleCount;
	}

	public int GetKillsAmount()
	{
		return killsAmount;
	}

	public void AddKillsAmount()
	{
		killsAmount++;
	}

	public float GetRemainTime()
	{
		return curTime;
	}

	public int getBaby1()
	{
		return apPlusCount;
	}

	public int getBaby2()
	{
		return apPlusCount2;
	}

	public int getBaby3()
	{
		return apPlusCount3;
	}

	public int getBaby4()
	{
		return apPlusCount4;
	}

	public int getBaby5()
	{
		return apPlusCount5;
	}

	public void addBaby1()
	{
		apPlusCount++;
	}

	public void addBaby2()
	{
		apPlusCount2++;
	}

	public void addBaby3()
	{
		apPlusCount3++;
	}

	public void addBaby4()
	{
		apPlusCount4++;
	}

	public void addBaby5()
	{
		apPlusCount5++;
	}
}
