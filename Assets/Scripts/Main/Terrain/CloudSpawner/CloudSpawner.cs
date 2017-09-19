using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class CloudSpawner : MonoBehaviour {
		public int boardSize;
		public GameObject[] puffClouds;
		public float xCoord, zCoord;

		void Start ()
		{
			boardSize = Settings.LandscapeSize();
			foreach (GameObject puffCloud in puffClouds) {
				Spawn(puffCloud);
			}
		}
		void Spawn (GameObject puffCloud)
		{
			xCoord = Random.Range(-boardSize/2f, boardSize/2f);
			zCoord = Random.Range(-boardSize/2f, boardSize/2f);
			Vector3 randPoint = new Vector3(xCoord, 5f, zCoord);
			var cloud = Instantiate (puffCloud, randPoint, Quaternion.identity);
			cloud.transform.parent = transform;
		}
	}
}
