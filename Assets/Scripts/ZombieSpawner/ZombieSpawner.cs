using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unorthoducks
{
	public class ZombieSpawner : MonoBehaviour, IDuckSpawner
	{
<<<<<<< HEAD
		private GameObject imageTarget;
    public float numberZombies;
=======
>>>>>>> ccab1e8de5f28ea2898d49ec19b4ffadf66596ca
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
<<<<<<< HEAD
			var newZombie = Instantiate(zombie, new Vector3(1f, 0.125f, 1f), Quaternion.identity) as Zombie;
			newZombie.transform.parent = imageTarget.transform;
=======
			var newZombie = Instantiate(zombie, new Vector3(2f, 2f, 2f), Quaternion.identity) as Zombie;
			newZombie.transform.parent = transform;
>>>>>>> ccab1e8de5f28ea2898d49ec19b4ffadf66596ca
		}
	}
}
