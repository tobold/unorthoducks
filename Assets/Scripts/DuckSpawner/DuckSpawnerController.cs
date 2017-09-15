using System;

namespace Unorthoducks
{
	[Serializable]
  public class DuckSpawnerController
  {
		private IDuckSpawner duckSpawner;

    public void Spawn ()
		{
      duckSpawner.Spawn ();
		}

    public void SetDuckSpawner ( IDuckSpawner spawner )
    {
      this.duckSpawner = spawner;
    }
  }
}
