using UnityEngine;

namespace Unorthoducks
{
	public class DuckSpawner : MonoBehaviour, IDuckSpawner
	{
		public Duck duck;
		public DuckSpawnerController controller;

		public void OnEnable ()
		{
			controller.SetDuckSpawner (this);
			controller.Initialise ();
		 }

		 public void Initialise ()
		 {
			 var target = Instantiate (duck, new Vector3(3f, 0.15f, 6f),
					Quaternion.identity) as Duck;
			 GameObject imageTarget = GameObject.Find("ImageTarget");
			 target.transform.parent = imageTarget.transform;
		 }
	}
}
