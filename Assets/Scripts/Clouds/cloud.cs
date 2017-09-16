using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class Cloud : MonoBehaviour
	{
		public float speed;
		public int boardSize;
		public Vector3 randPoint;

		public void Start ()
		{
			boardSize = Settings.LandscapeSize ();
			float randomTime = Random.Range(3f, 6f);
			InvokeRepeating("ChangeDirection", 0f, randomTime);
		}

		public void Update ()
		{
			Move();
		}

		public void Move ()
		{
			float step = 0.5f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, randPoint, step);
		}

		public void ChangeDirection ()
		{
			var x = Random.Range(-boardSize/1.5f, boardSize/1.5f);
			var z = Random.Range(-boardSize/1.5f, boardSize/1.5f);
			randPoint = new Vector3(x, 5f, z);
		}
	}
}
