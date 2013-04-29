using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	public AudioClip Bite;
	public AudioClip Eat;
	public AudioClip Spit;
	public AudioClip Hurt;
	
	private CharacterController controller;
	private Transform mouth;
	private int health;
	
	public GameObject Item{ get; private set; }
	public int Health
	{ 
		get
		{
			return health;	
		}
		private set
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
		Move();
		if(Item != null)
		{
			Item.transform.position = mouth.position;
			Item.transform.rotation = mouth.rotation;
			
			//shoot the item
			if(Input.GetKey(KeyCode.Space))
			{
				Item.rigidbody.velocity = mouth.up * 80;
				Item.layer = 0;
				Item = null;
				PlaySound(Spit);
			}
			//eat the item
			if(Input.GetKey(KeyCode.E))
			{
				if(Item.GetComponent<Potato>() != null)
				{
					Health += 10;
					Destroy(Item);
					PlaySound(Eat);
				}
				else if(Item.GetComponent<PeeledPotato>() != null)
				{
					Application.LoadLevel("Ending2");
				}
			}
		}
		
		if(Health == 0)
		{
			Application.LoadLevel("GameOver");
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
		if(collider.gameObject.tag == "Potato")
		{
			if(Item == null)
			{
				Item = collider.gameObject;
				Item.layer = 8;
				PlaySound(Bite);
			}
		}
		else if(collider.gameObject.tag == "Enemy")
		{
			Health -= 20;
			PlaySound(Hurt);
		}
	}
	
	private void PlaySound(AudioClip sound)
	{
		audio.clip = sound;
		audio.Play();
	}
}
