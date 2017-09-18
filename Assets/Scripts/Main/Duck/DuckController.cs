using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class DuckController
  {
		private IDuckMovementController duckMovementController;

    public void Move ()
    {
      duckMovementController.Move();
    }

		public void Direction ()
		{
			duckMovementController.Direction();
		}

    public void SetDuckMovementController ( IDuckMovementController duckMovementController )
		{
			this.duckMovementController = duckMovementController;
		}
  }
}
