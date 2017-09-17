using UnityEngine;

namespace Unorthoducks
{
	public class Landscape : MonoBehaviour, ILandscapeController
	{
    public LandscapeController landscapeController;
    public GameObject landscape;
    public GameObject cave;
    public int boardSize;

    public void Start ()
    {
			boardSize = Settings.LandscapeSize();
      landscapeController.SetLandscapeController (this);
      landscapeController.Initialise();
    }

    public void Initialise ()
    {
			SpawnFloor();
			SpawnCaves();
    }

		public void SpawnFloor ()
		{
			var floor = Instantiate (landscape, new Vector3(0, -0.05f, 0),
				Quaternion.identity) as GameObject;
			Resize (floor);
			floor.transform.parent = transform;
		}

		public void SpawnCaves ()
		{
			float angle = 0;
			GameObject newCave;
			for(int i = 0; i < 4; i++) {
				newCave = Instantiate(cave, CavePosition(i),
					Quaternion.Euler(0, angle, 0)) as GameObject;
				newCave.transform.parent = transform;
				angle += 90;
			}
		}

		public Vector3 CavePosition (int rotation)
		{
			float xCoord, zCoord;
			float boardEdge = boardSize / 2f + 0.15f;
			if(rotation % 2 == 0) {
				zCoord = 0;
				xCoord = rotation == 0 ? boardEdge : -boardEdge;
			} else {
				xCoord = 0;
				zCoord = rotation == 1 ? boardEdge : -boardEdge;
			}
			return new Vector3(xCoord, 0, zCoord);
		}

		private void Resize (GameObject floor)
		{
			var x = boardSize * 1.1;
			var y = boardSize * 1.1;
			floor.transform.localScale = new Vector3((float)x, 0.1f, (float)y);
		}
  }
}
