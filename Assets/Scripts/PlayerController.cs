using System;
using UnityEngine;

namespace Unorthoducks
{
	[Serializable]
  public class PlayerController
  {
		private IGunController gunController;

    public void ApplyFire ()
		{
			gunController.Fire ();
		}

    public void SetGunController ( IGunController gunController )
		{
			this.gunController = gunController;
		}
  }
}
