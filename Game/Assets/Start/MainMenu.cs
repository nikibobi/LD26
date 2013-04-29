using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUISkin Skin;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.isPlaying == false || Input.anyKeyDown)
		{
			Application.LoadLevel("Main");	
		}
	}
	
	void OnGUI()
	{
		GUI.skin = Skin;
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Game by Borislav and Viktor for Ludum Dare 26");
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
