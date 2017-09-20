using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class Cloud : MonoBehaviour, ICloudMovementController
	{
		public CloudController cloudController;
		public BoardLocationFinder locationFinder;
		public float speed;
		public int boardSize;
		public Vector3 randPoint;

		public void Start ()
		{
			cloudController.SetCloudMovementController(this);
			boardSize = Settings.LandscapeSize ();
			float randomTime = Random.Range(3f, 6f);
			InvokeRepeating("ChangeDirection", 0f, randomTime);
		}

		public void Update ()
		{
			cloudController.Move();
		}

		public void Move ()
		{
			float step = 0.5f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, randPoint, step);
		}

		public void ChangeDirection ()
		{
			randPoint = locationFinder.RandomLocation(3f, 100f);
			// var x = Random.Range(-boardSize/1.5f, boardSize/1.5f);
			// var z = Random.Range(-boardSize/1.5f, boardSize/1.5f);
			// randPoint = new Vector3(x, 3f, z);
		}
	}
}
