using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedAppearance : MonoBehaviour {
	private GameObject gameObject;

	void Start () {
		gameObject = GameObject.Find("RestartButton");
		gameObject.SetActive(false);
		Invoke("Enable", 1.5f);
	}

	void Enable () {
		gameObject.SetActive(true);
	}
}
