using UnityEngine;
using System.Collections;

public class PlayerProgressManager : MonoBehaviour 
{
	public int playerLives;
	private int playerPoints;
	private int numberOfBlocks;
	private GameObject feildExtender;

	private static PlayerProgressManager instance;
	public static PlayerProgressManager Instance { get { return instance; } }

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		feildExtender = GameObject.Find("FieldExtender");
		playerLives = 10;
		playerPoints = 0;
	}

	public void getNumberOfBlocks()
	{
		numberOfBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
	}

	public void takeLife()
	{
		playerLives--;
		SoundManager.instance.playSound(SoundManager.COMMON_SOUND_LOOSE_LIFE, SoundManager.SoundTipe.CommonSound);
		if (playerLives <= 0) 
		{
			Application.LoadLevel("GameField");
		}
	}

	public void checkWin()
	{
		numberOfBlocks--;
		if(numberOfBlocks <= 0)
		{
			feildExtender.GetComponent<FieldExtender>().extendGameField();
			numberOfBlocks--; //decrement last block on the game field
		}
	}

	public void addPoints(int points)
	{
		playerPoints += points;
		SoundManager.instance.playSound(SoundManager.COMMON_SOUND_TAKE_POINT, SoundManager.SoundTipe.CommonSound);
	}
		
	void OnGUI()
	{
		GUIStyle labelGUIStyle = new GUIStyle();
		labelGUIStyle.alignment = TextAnchor.UpperLeft;
		labelGUIStyle.fontStyle = FontStyle.Bold;
		labelGUIStyle.fontSize = Screen.height/20;
		GUI.Label (new Rect(5.0f,3.0f,Screen.width/20,Screen.height/20),"Live's: " + playerLives + "  Score: " + playerPoints,labelGUIStyle);
	}
}
