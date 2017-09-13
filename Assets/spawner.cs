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
		Vector3 startvelocity = Camera.main.transform.forward;
		// startvelocity.y = 0.5f;
    startvelocity = startvelocity.normalized * 10;
		sphere.GetComponent<Rigidbody> ().velocity = startvelocity;
		sphere.transform.position = Camera.main.transform.position;
	}

	// Update is called once per frame
	void Update () {

	}
}
