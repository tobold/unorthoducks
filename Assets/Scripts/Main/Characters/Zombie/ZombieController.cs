using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class ZombieController
  {
		private IDuckMovementController zombieMovementController;

    public void FindEnemies ()
		{
      zombieMovementController.FindEnemies();
		}

    public void Move ()
    {
      zombieMovementController.Move();
    }

    public void SetMovementController ( IDuckMovementController zombieMovementController )
		{
			this.zombieMovementController = zombieMovementController;
		}
  }
}
