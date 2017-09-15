using UnityEngine;

namespace Unorthoducks
{
	public class DuckSpawner : MonoBehaviour, IDuckSpawner
	{
		public Duck duck;
		public DuckSpawnerController controller;
		public int numberDucks;

		public void Start ()
		{
			numberDucks = 0;
			controller.SetDuckSpawner (this);
			CreateDucks();
		}

		public void CreateDucks ()
		{
			while(numberDucks < 3)
			{
				controller.Spawn ();
			}
		}

		public void Spawn ()
		{
			if (this.gameObject.activeSelf) {
				var target = Instantiate (duck, new Vector3 (3f, 0.15f, 6f),
					              Quaternion.identity) as Duck;
				target.transform.parent = transform;
				numberDucks += 1;
			}
		}
	}
}
