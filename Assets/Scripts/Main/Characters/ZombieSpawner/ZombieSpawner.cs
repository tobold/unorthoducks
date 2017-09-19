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
			controller.SetZombieSpawner (this);
		}

		public void Init() {
			CancelInvoke();
			numberZombies = 0;
			if(this.gameObject.activeSelf) {
				spawnPoints = GameObject.FindGameObjectsWithTag("ZombieSpawn");
				InvokeRepeating("CreateZombieDucks", 2f, GameManager.GetSpawnRate());
			}
		}

		private void CreateZombieDucks()
		{
			if(numberZombies < GameManager.GetZombiesToSpawn() && this.gameObject.activeSelf)
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
																					spawnPoint.y + 0.2f,
																					spawnPoint.z);
			var newZombie = Instantiate(zombie, spawnPosition, Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
		}
	}
}
