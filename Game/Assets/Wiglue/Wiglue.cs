using UnityEngine;
using System.Collections;

public class Wiglue : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	public AudioClip Die;
	
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
			Destroy(gameObject);
		}
		else if(collider.gameObject.tag == "Potato")
		{
			if(collider.GetComponent<Potato>() != null)
			{
				player.GetComponent<Character>().Score += 10 * (int)Vector3.Distance(transform.position, player.transform.position);
				Destroy(collider.gameObject);
				Destroy(gameObject);
			}
			else if(collider.GetComponent<PeeledPotato>() != null)
			{
				Application.LoadLevel("Ending1");	
			}
		}
	}
}
