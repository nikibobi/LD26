using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public float RotationSpeed;
	public float MoveSpeed;
	
	public GameObject Item;
	
	private CharacterController controller;
	private Transform mouth;
	
	// Use this for initialization
	void Start () {
		//Physics.gravity = new Vector3(0,-50,0);
		controller = GetComponent<CharacterController>();
		mouth = transform.FindChild("Mouth");
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		if(Item != null)
		{
			Item.transform.position = mouth.position;
			Item.transform.rotation = mouth.rotation;
			
			if(Input.GetKey(KeyCode.Space))
			{
				Item.rigidbody.velocity = mouth.up * 70;
				Item = null;
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
