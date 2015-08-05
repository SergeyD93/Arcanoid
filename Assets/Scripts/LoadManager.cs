using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {

	private AsyncOperation async = null;
	private bool isLoading = false;
	public string levelName = "";
	public Texture backgroundBar;
	public Texture lineBar;
	public Texture GUITextureBackground;
	
	private IEnumerator StartLoad()
	{
		Debug.Log( "Loading... " );
		async = Application.LoadLevelAsync( levelName );
		while( !async.isDone )
		{
			Debug.Log( string.Format( "Loading {0}%", async.progress*100 ) );
			yield return null;
		}
		Debug.Log( "Loading complete" );
		isLoading = false;
		yield return async;
	}
	
	private void OnGUI()
	{
		GUIStyle mainLabelGUIStyle = new GUIStyle();
		mainLabelGUIStyle.alignment = TextAnchor.MiddleCenter;
		mainLabelGUIStyle.fontStyle = FontStyle.Bold;
		mainLabelGUIStyle.fontSize = 30;

		GUIStyle newGUIStyle = new GUIStyle();
		newGUIStyle.alignment = TextAnchor.MiddleCenter;
		newGUIStyle.fontStyle = FontStyle.Bold;
		newGUIStyle.fontSize = 14;
		int progressBarWidth = System.Convert.ToInt32(Screen.width*0.8);
		int progressBarHeight = System.Convert.ToInt32(Screen.height*0.05);

		int mainLabelWidth = Screen.width;
		int mainLabelHeight = Screen.height/4;

		if(GUITextureBackground != null)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), GUITextureBackground);
		if( !isLoading )
		{
			{
				isLoading = true;
				StartCoroutine("StartLoad"); 
			}
		}
		else
		{
			GUI.Label(new Rect((Screen.width/2)-mainLabelWidth/2, Screen.height/2 - mainLabelHeight/2, mainLabelWidth, mainLabelHeight),"SERGEY DURNEV DEMO PROJECT", mainLabelGUIStyle);

			GUI.Label(new Rect((Screen.width/2)-progressBarWidth/2, Screen.height - progressBarHeight*4, progressBarWidth, progressBarHeight*2),"Loading...", newGUIStyle);
			GUI.DrawTexture( new Rect((Screen.width / 2) - progressBarWidth/2, Screen.height - progressBarHeight*2, progressBarWidth, progressBarHeight ), backgroundBar, ScaleMode.StretchToFill, true, 1F);
			GUI.DrawTexture( new Rect((Screen.width / 2) - progressBarWidth/2, Screen.height - progressBarHeight*2, async.progress*progressBarWidth, progressBarHeight), lineBar, ScaleMode.StretchToFill, true, 1F);
		}
	}
}
