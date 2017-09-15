using System;

namespace Unorthoducks
{
	[Serializable]
	public class ZombieSpawnerController {

		private IZombieSpawner zombieSpawner;

		public void SpawnZombie ()
		{
			zombieSpawner.SpawnZombie ();
		}

		public void SetZombieSpawner(IZombieSpawner zombieSpawner)
		{
			this.zombieSpawner = zombieSpawner;
		}
	}
}
