using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	public GUISkin Skin;
	
	private Character character;
	
	// Use this for initialization
	void Start()
	{
		character = GameObject.Find("Character").GetComponent<Character>();
	}
	
	void OnGUI()
	{
		GUI.skin = Skin;
		GUILayout.BeginHorizontal();
			GUILayout.Label(character.Health.ToString());
			GUILayout.HorizontalSlider(character.Health, 0, 100, GUILayout.Width(300));
		GUILayout.EndHorizontal();
	}
}
