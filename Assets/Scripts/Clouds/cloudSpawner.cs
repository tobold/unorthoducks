using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour {
	
	public GameObject puffCloud;
	public GameObject puffCloud_0;
	public GameObject puffCloud_1;

	void Start ()
	{
		Instantiate (puffCloud);
		Instantiate (puffCloud_0);
		Instantiate (puffCloud_1);
	}
}
