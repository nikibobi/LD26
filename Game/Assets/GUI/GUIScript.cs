using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	public GUISkin Skin;
	public Texture FaceCamera;
	public Texture HealthbarEmpty;
	public Texture HealthbarFull;
	
	public Vector2 BarPos;
	public Vector2 BarSize;
	
	private Character character;
	private int w;
	private int h;
	
	// Use this for initialization
	void Start()
	{
		character = GameObject.Find("Character").GetComponent<Character>();
		w = Screen.width;
		h = Screen.height;
		BarSize = new Vector2(230, 32);
		BarPos = new Vector2(w - BarSize.x - 10, 10);
	}
	
	void OnGUI()
	{
		GUI.skin = Skin;
		GUI.Label(new Rect(10, 0, 400, 64), "Score: " + character.Score.ToString());
		GUI.Label(new Rect(w - FaceCamera.width, h - FaceCamera.height, FaceCamera.width, FaceCamera.height), FaceCamera);
		
	    GUI.BeginGroup(new Rect (BarPos.x, BarPos.y, BarSize.x, BarSize.y));
	        GUI.Box(new Rect(0, 0, BarSize.x, BarSize.y), HealthbarEmpty);
	        // draw the filled-in part:
	        GUI.BeginGroup(new Rect (0, 0, BarSize.x * character.Health / 100f, BarSize.y));
	            GUI.Box(new Rect(0, 0, BarSize.x, BarSize.y), HealthbarFull);
	        GUI.EndGroup();
	    GUI.EndGroup();
	}
}
