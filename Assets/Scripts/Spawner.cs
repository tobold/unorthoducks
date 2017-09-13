using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Mesh mesh;
	public Material material;

	// Use this for initialization
	public void SpawnSphere () {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.AddComponent<Rigidbody>();
		Vector3 startvelocity = Camera.main.transform.forward;
    startvelocity = startvelocity.normalized * 20;
		sphere.GetComponent<Rigidbody> ().velocity = startvelocity;
		sphere.transform.position = Camera.main.transform.position;
		sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
	}

	// Update is called once per frame
	void Update () {

	}
}
