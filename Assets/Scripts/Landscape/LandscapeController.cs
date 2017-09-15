using System;
using UnityEngine;

namespace Unorthoducks
{
  [Serializable]
	public class LandscapeController
	{
    private ILandscapeController landscapeController;

    public void SetLandscapeController ( ILandscapeController landscapeController )
		{
			this.landscapeController = landscapeController;
		}

    public void Initialise ()
    {
      landscapeController.Initialise ();
    }
  }
}
