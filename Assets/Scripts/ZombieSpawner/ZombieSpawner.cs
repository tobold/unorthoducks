using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, ISpawner
	{
		public GameObject[] spawnPoints;
		public Zombie zombie;
		public ZombieSpawnerController controller;
		public int numberZombies;

		private void Start () {
      numberZombies = 0;
			controller.SetZombieSpawner (this);
			if(this.gameObject.activeSelf) {
				spawnPoints = GameObject.FindGameObjectsWithTag("ZombieSpawn");
				InvokeRepeating("CreateZombieDucks", 1f, 2f);
			}
		}

		private void CreateZombieDucks()
		{
			if(numberZombies < 4 && this.gameObject.activeSelf)
      {
        controller.Spawn ();
        numberZombies += 1;
      }
		}

		public void Spawn ()
		{
			int r = Random.Range(1, spawnPoints.Length);
			Vector3 spawnPoint = spawnPoints[r].transform.position;
			Vector3 spawnPosition = new Vector3(spawnPoint.x,
																					spawnPoint.y + 0.125f,
																					spawnPoint.z);
			var newZombie = Instantiate(zombie, spawnPosition, Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
		}
	}
}
