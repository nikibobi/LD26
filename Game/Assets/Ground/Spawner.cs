using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] Rocks;
	public GameObject PeeledPotato;
	public GameObject Potato;
	public GameObject Wiglue;
	
	private float wiglueCurTime;
	private float totalTime;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range(10, 50); i++)
		{
			var prefab = Rocks[Random.Range(0, 2)];
			var position = SpawnPoint(0.1f);
			var rotation = Random.rotation;
			var scale = Random.Range(0.80f, 1.10f);
			var obj = Instantiate(prefab, position, rotation) as GameObject;
			obj.transform.localScale = new Vector3(scale, scale, scale);
		}
		
		for (int i = 0; i < Random.Range(1, 3); i++) {
			SpawnWiglue();
			SpawnPotato();
			SpawnPotato();
		}
	}
	
	// Update is called once per frame
	void Update () {
		wiglueCurTime += Time.deltaTime;
		totalTime += Time.deltaTime;
		
		
		if(wiglueCurTime > 5f)
		{
			SpawnWiglue();
			SpawnPotato();
			SpawnPotato();
			SpawnPotato();
			wiglueCurTime = 0;
		}
		
		
		if(totalTime > 60f * 0.1f && GameObject.FindObjectOfType(typeof(PeeledPotato)) == null)
		{
			SpawnPeeledPotato();
		}
	}
	
	private void SpawnWiglue()
	{
		Instantiate(Wiglue, SpawnPoint(1f), Quaternion.identity);
	}
	
	private void SpawnPeeledPotato()
	{
		Instantiate(PeeledPotato, SpawnPoint(1f), Quaternion.identity);
	}
	
	private void SpawnPotato()
	{
		Instantiate(Potato, SpawnPoint(1f), Quaternion.identity);
	}
	
	private Vector3 SpawnPoint(float y)
	{
		var x = transform.lossyScale.x / 2f * 0.9f;
		var z = transform.lossyScale.z / 2f * 0.9f;
		var position = new Vector3(Random.Range(-x, x), y, Random.Range(-z, z));
		return position;
	}
}
