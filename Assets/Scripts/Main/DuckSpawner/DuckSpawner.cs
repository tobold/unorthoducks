using UnityEngine;

namespace Unorthoducks
{
	public class DuckSpawner : MonoBehaviour, ISpawner
	{
		public Duck duck;
		public DuckSpawnerController controller;
		public int numberDucks;
		public int boardSize;

		public void Start ()
		{
			numberDucks = 0;
			boardSize = Settings.LandscapeSize();
			controller.SetDuckSpawner (this);
			CreateDucks();
		}

		public void CreateDucks ()
		{
			while(numberDucks < 8)
			{
				controller.Spawn ();
			}
		}

		public void Spawn ()
		{
			if (this.gameObject.activeSelf) {
				var x = Random.Range(-boardSize/2f, boardSize/2f);
				var y = Random.Range(-boardSize/2f, boardSize/2f);
				var newDuck = Instantiate (duck, new Vector3 (x, 0.125f, y),
					              Quaternion.identity) as Duck;
				newDuck.transform.parent = transform;
				numberDucks += 1;
			}
		}
	}
}
