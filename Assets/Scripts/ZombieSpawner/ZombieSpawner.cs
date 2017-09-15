using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, IZombieSpawner
	{
    	public float numberZombies;
		public Zombie zombie;
		public ZombieSpawnerController controller;

		private void Start () {
      		numberZombies = 0;
			controller.SetZombieSpawner (this);
			InvokeRepeating("Spawn", 1f, 1f);
		}

		private void Spawn()
		{
			if(numberZombies < 5 && this.gameObject.activeSelf)
      		{
        		controller.SpawnZombie ();
        		numberZombies += 1;
      		}
		}

//		implementation of IDuckSpawner

		public void SpawnZombie ()
		{
			var newZombie = Instantiate(zombie, new Vector3(2f, 2f, 2f), Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
		}
	}
}
