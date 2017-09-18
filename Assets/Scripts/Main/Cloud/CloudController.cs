using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class CloudController
  {
		private ICloudMovementController cloudMovementController;

    public void Move ()
    {
      cloudMovementController.Move();
    }

    public void SetCloudMovementController ( ICloudMovementController cloudMovementController )
		{
			this.cloudMovementController = cloudMovementController;
		}
  }
}
