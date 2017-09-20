using UnityEngine;

namespace Unorthoducks
{
	public class DuckSpawner : MonoBehaviour, ISpawner
	{
		public Duck duck;
		public DuckSpawnerController controller;
		public int numberDucks;

		public void Start ()
		{
			controller.SetDuckSpawner (this);
		}

		public void Init ()
		{
			numberDucks = 0;
			CreateDucks();
		}

		public void CreateDucks ()
		{
			while(numberDucks < 8) controller.Spawn ();
		}

		public void Spawn ()
		{
			int boardSize = Settings.LandscapeSize();
			if (this.gameObject.activeSelf) {
				var x = Random.Range(-boardSize/2f, boardSize/2f);
				var y = Random.Range(-boardSize/2f, boardSize/2f);
				var newDuck = Instantiate (duck, new Vector3 (x, 0.2f, y),
					              Quaternion.identity) as Duck;
				newDuck.transform.parent = transform;
				numberDucks += 1;
			}
		}
	}
}
