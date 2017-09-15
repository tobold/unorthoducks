using System;

namespace Unorthoducks
{
	[Serializable]
	public class ZombieSpawnerController {

		private IDuckSpawner zombieSpawner;

		public void SpawnZombie ()
		{
			zombieSpawner.Spawn ();
		}

		public void SetZombieSpawner(IDuckSpawner zombieSpawner)
		{
			this.zombieSpawner = zombieSpawner;
		}
	}
}
