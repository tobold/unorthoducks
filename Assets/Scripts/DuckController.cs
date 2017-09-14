using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class DuckController
  {
		private IDuckController duckController;

    public void Initialise ()
		{
      duckController.Initialise ();
		}

    public void SetDuckController ( IDuckController duckController )
    {
      this.duckController = duckController;
    }

  }
}
