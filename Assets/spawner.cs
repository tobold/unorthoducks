using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Mesh mesh;
	public Material material;

	// Use this for initialization
	public void SpawnSphere () {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.AddComponent<Rigidbody>();
		sphere.transform.position = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
