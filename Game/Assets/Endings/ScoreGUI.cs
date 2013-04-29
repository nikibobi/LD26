using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
	
	public GUISkin Skin;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			Application.LoadLevel("Start");
		}
	}
	
	void OnGUI () {
		GUI.skin = Skin;
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUILayout.BeginVertical();
			GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Score: " + GameObject.Find("HighScore").GetComponent<HighScore>().Score);
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
