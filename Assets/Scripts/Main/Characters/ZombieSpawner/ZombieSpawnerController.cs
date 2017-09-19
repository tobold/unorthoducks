using System;

namespace Unorthoducks
{
	[Serializable]
	public class ZombieSpawnerController {

		private ISpawner zombieSpawner;

		public void Spawn ()
		{
			zombieSpawner.Spawn ();
		}

		public void SetZombieSpawner(ISpawner zombieSpawner)
		{
			this.zombieSpawner = zombieSpawner;
		}
	}
}
