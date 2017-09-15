using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, IZombieSpawner
	{
		private GameObject imageTarget;
    public float numberZombies;
		public Zombie zombie;
		public ZombieSpawnerController controller;

		private void OnEnable () {
      numberZombies = 0;
			imageTarget = GameObject.Find("ImageTarget");
			controller.SetZombieSpawner (this);
			InvokeRepeating("Spawn", 1f, 1f);
		}

		private void Spawn()
		{
      if(numberZombies < 5)
      {
        controller.SpawnZombie ();
        numberZombies += 1;
      }
		}

//		implementation of IDuckSpawner

		public void SpawnZombie ()
		{
			var newZombie = Instantiate(zombie, new Vector3(2f, 2f, 2f), Quaternion.identity) as Zombie;
			newZombie.transform.parent = imageTarget.transform;
		}
	}
}
