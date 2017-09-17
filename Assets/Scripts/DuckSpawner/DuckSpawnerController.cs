using System;

namespace Unorthoducks
{
	[Serializable]
  public class DuckSpawnerController
  {
		private ISpawner duckSpawner;

    public void Spawn ()
		{
      duckSpawner.Spawn ();
		}

    public void SetDuckSpawner ( ISpawner spawner )
    {
      this.duckSpawner = spawner;
    }
  }
}
