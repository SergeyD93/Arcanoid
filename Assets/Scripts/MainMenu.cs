using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	private bool optionsMenuTrigger = false;

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

		if(!optionsMenuTrigger)
		{

			

			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 - System.Convert.ToInt32(buttonHeight*1.5), buttonWidth, buttonHeight),"Start Game"))
			{
				Application.LoadLevel("Loader");
			}

			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2, buttonWidth, buttonHeight), "Options"))
			{
				optionsMenuTrigger = true;
			}

			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 + buttonHeight + System.Convert.ToInt32(buttonHeight*0.5), buttonWidth, buttonHeight), "Exit"))
			{
				Application.Quit();
			}
		}
		else
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

			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 - System.Convert.ToInt32(buttonHeight*1.5), buttonWidth, buttonHeight), buttonSoundLabel))
			{
				UserData.soundsOnTrigger = !UserData.soundsOnTrigger;
			}

			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2, buttonWidth, buttonHeight), buttonMusicLabel))
			{
				UserData.musicOnTrigger = !UserData.musicOnTrigger;
			}
			if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 + buttonHeight + System.Convert.ToInt32(buttonHeight*0.5), buttonWidth, buttonHeight), "Back"))
			{
				optionsMenuTrigger = false;
			}
		}
	}
}
