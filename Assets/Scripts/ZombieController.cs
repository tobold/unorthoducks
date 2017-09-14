using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class ZombieController
  {
		private IZombieMovementController zombieMovementController;

    public void FindDucks ()
		{
      zombieMovementController.FindDucks();
		}

    public void Move ()
    {
      zombieMovementController.Move();
    }

    public void SetZombieMovementController ( IZombieMovementController zombieMovementController )
		{
			this.zombieMovementController = zombieMovementController;
		}
  }
}
