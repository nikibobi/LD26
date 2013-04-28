using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	public AudioClip Bite;
	public AudioClip Spit;
	
	private CharacterController controller;
	private Transform mouth;
	private int health;
	
	public int HP;
	
	public GameObject Item{ get; private set; }
	public int Health
	{ 
		get
		{
			return health;	
		}
		set
		{
			health = Mathf.Clamp(value, 0, 100);
		}
	}
	public int Score{ get; set; }
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		mouth = transform.FindChild("Mouth");
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		HP = Health;
		Move();
		if(Item != null)
		{
			Item.transform.position = mouth.position;
			Item.transform.rotation = mouth.rotation;
			
			//shoot the item
			if(Input.GetKey(KeyCode.Space))
			{
				Item.rigidbody.velocity = mouth.up * 80;
				Item = null;
				PlaySound(Spit);
			}
			//eat the item
			if(Input.GetKey(KeyCode.E))
			{
				Health += 10;
				Destroy(Item);
				PlaySound(Bite);
			}
		}
	}
	
	void Move()
	{
		var direction = transform.forward * Input.GetAxis("Vertical");
		var rotation = Input.GetAxis("Horizontal");
		
		transform.RotateAroundLocal(Vector3.up, rotation * RotationSpeed * Time.deltaTime);
		controller.Move(direction * MoveSpeed * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, 1, transform.position.z);
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(Item == null)
		{
			if(collider.gameObject.tag == "Potato")
			{
				Item = collider.gameObject;
			}
		}
	}
	
	private void PlaySound(AudioClip sound)
	{
		if(audio.isPlaying == false)
		{
			audio.clip = sound;
			audio.Play();
		}
	}
}
