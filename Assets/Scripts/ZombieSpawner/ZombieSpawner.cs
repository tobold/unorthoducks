using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, IDuckSpawner
	{
		public Zombie zombie;
		public ZombieSpawnerController controller;
		public int numberZombies;

		private void Start () {
      numberZombies = 0;
			controller.SetZombieSpawner (this);
			InvokeRepeating("CreateZombieDucks", 1f, 1f);
		}

		private void CreateZombieDucks()
		{
			if(numberZombies < 5 && this.gameObject.activeSelf)
      {
        controller.SpawnZombie ();
        numberZombies += 1;
      }
		}

//		implementation of IDuckSpawner

		public void Spawn ()
		{
			var newZombie = Instantiate(zombie, new Vector3(2f, 2f, 2f), Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
		}
	}
}
