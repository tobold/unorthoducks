using UnityEngine;

namespace Unorthoducks
{
	public class DuckSpawner : MonoBehaviour, IDuckSpawner
	{
		public Duck duck;
		public DuckSpawnerController controller;

		public void Start ()
		{
			controller.SetDuckSpawner (this);
			controller.CreateDucks ();
		 }

		 public void CreateDucks ()
		{
			if (this.gameObject.activeSelf) {

				var target = Instantiate (duck, new Vector3 (3f, 0.15f, 6f),
					              Quaternion.identity) as Duck;
				target.transform.parent = transform;
			}
		}
	}
}
