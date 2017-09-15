using System;

namespace Unorthoducks
{
	[Serializable]
  public class DuckSpawnerController
  {
		private IDuckSpawner duckSpawner;

    public void CreateDucks ()
		{
      duckSpawner.CreateDucks ();
		}

    public void SetDuckSpawner ( IDuckSpawner spawner )
    {
      this.duckSpawner = spawner;
    }
  }
}
