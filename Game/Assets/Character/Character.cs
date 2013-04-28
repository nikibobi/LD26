using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	
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
		private set
		{
			health = Mathf.Clamp(value, 0, 100);
		}
	}
	
	// Use this for initialization
	void Start () {
		//Physics.gravity = new Vector3(0,-50,0);
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
			}
			//eat the item
			if(Input.GetKey(KeyCode.E))
			{
				Health += 10;
				Destroy(Item);
			}
		}
	}
	
	void Move()
	{
		var direction = transform.forward * Input.GetAxis("Vertical");
		var rotation = Input.GetAxis("Horizontal");
		transform.RotateAroundLocal(Vector3.up, rotation * RotationSpeed * Time.deltaTime);
		controller.Move(direction * MoveSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider colider)
	{
		if(Item == null)
		{
			if(colider.gameObject.tag == "Potato")
			{
				Item = colider.gameObject;
			}
		}
	}
}
