using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, ISpawner
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
			if(numberZombies < 1 && this.gameObject.activeSelf)
      {
        controller.Spawn ();
        numberZombies += 1;
      }
		}

		public void Spawn ()
		{
			var newZombie = Instantiate(zombie, new Vector3(1f, 0.125f, 1f),
			Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
		}
	}
}
