using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class DuckSpawnerController
  {
		private IDuckSpawner duckSpawner;

    public void Initialise ()
		{
      duckSpawner.Initialise ();
		}

    public void SetDuckSpawner ( IDuckSpawner spawner )
    {
      this.duckSpawner = spawner;
    }

  }
}
