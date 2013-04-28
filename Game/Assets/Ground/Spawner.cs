using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] Rocks;
	
	private Character character;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range(10, 50); i++)
		{
			var prefab = Rocks[Random.Range(0, 2)];
			var rotation = Random.rotation;
			var x = transform.lossyScale.x / 2f * 0.9f;
			var z = transform.lossyScale.z / 2f * 0.9f;
			var position = new Vector3(Random.Range(-x, x), 0.1f, Random.Range(-z, z));
			var scale = Random.Range(0.80f, 1.10f);
			var obj = Instantiate(prefab, position, rotation) as GameObject;
			obj.transform.localScale = new Vector3(scale, scale, scale);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
