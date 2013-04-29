using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	
	public int Score{ get; private set; }
	
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Character") != null && GameObject.Find("Character").GetComponent<Character>() != null)
		{
			Score = GameObject.Find("Character").GetComponent<Character>().Score;
		}
	}
}
