using UnityEngine;
using System.Collections;

public class Wiglue : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	
	private float currentTime;
	private float maxTime;
	private float rotation;
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		Move();
	}
	
	void Move()
	{
		transform.LookAt(player.transform);
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		transform.Translate(-transform.forward * MoveSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject == player)
		{
			player.GetComponent<Character>().Health -= 20;
			Destroy(gameObject);
		}
		else if(collider.gameObject.tag == "Potato")
		{
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
