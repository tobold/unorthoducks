using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour {
	
	public GameObject puffCloud;

	void Start () 
		{
		for (int i = 0; i < 1; i++)
			Instantiate (puffCloud);
		}
}
