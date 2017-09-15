using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {

	public float speed;  
	public Transform[] target;
	private int current;

	void Start () 
	{
		

	}
	void Update ()
	{ 
		if (transform.position != target [current].position) {
			Vector3 pos = Vector3.MoveTowards (transform.position, target [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);

		} else
			current = (current + 1) % target.Length;
	}
}


