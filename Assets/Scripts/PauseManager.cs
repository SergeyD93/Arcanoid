using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour 
{
	private bool pauseTrigger = false;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void OnGUI() 
	{
		int buttonWidth = Screen.width/3;
		int buttonHeight = Screen.height/10;
		int moddleOfScreenHorisontal = Screen.width/2 - buttonWidth/2;
		int moddleOfScreenVertical = Screen.height/2 - buttonHeight/2;
		int distansceBetweenButtons = buttonHeight/2;

		if(pauseTrigger)
		{
			string buttonSoundLabel;
			string buttonMusicLabel;
			
			if(UserData.soundsOnTrigger)
			{
				buttonSoundLabel = "Sounds ON";
			}
			else
			{
				buttonSoundLabel = "Sounds OFF";
			}
			
			if(UserData.musicOnTrigger)
			{
				buttonMusicLabel = "Music ON";
			}
			else
			{
				buttonMusicLabel = "Music OFF";
			}

			if (GUI.Button(new Rect(moddleOfScreenHorisontal, moddleOfScreenVertical - buttonHeight*2 - distansceBetweenButtons, buttonWidth, buttonHeight), "Resume"))
			{
				pauseTrigger = false;
				Time.timeScale = 1;
			}
			
			if (GUI.Button(new Rect(moddleOfScreenHorisontal, moddleOfScreenVertical - buttonHeight/2 - distansceBetweenButtons/2, buttonWidth, buttonHeight), buttonSoundLabel))
			{
				UserData.soundsOnTrigger = !UserData.soundsOnTrigger;
			}
			
			if (GUI.Button(new Rect(moddleOfScreenHorisontal, moddleOfScreenVertical + buttonHeight/2 + distansceBetweenButtons/2, buttonWidth, buttonHeight), buttonMusicLabel))
			{
				UserData.musicOnTrigger = !UserData.musicOnTrigger;
				SoundManager.instance.backgroundMusicSwitch(UserData.musicOnTrigger);
			}
			
			if (GUI.Button(new Rect(moddleOfScreenHorisontal, moddleOfScreenVertical + buttonHeight*2 + distansceBetweenButtons, buttonWidth, buttonHeight), "Exit"))
			{
				Application.Quit();
			}
		}
		else
		{
			if (GUI.Button(new Rect(Screen.width - Screen.width/9, Screen.height/40, Screen.width/10, Screen.height/10), "Pause"))
			{
				pauseTrigger = true;
				Time.timeScale = 0; 
			}
		}
	}
}
