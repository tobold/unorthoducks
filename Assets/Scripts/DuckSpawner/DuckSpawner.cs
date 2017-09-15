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
			 var target = Instantiate (duck, new Vector3(0f, 0.125f, 0f),
					Quaternion.identity) as Duck;
			 GameObject imageTarget = GameObject.Find("ImageTarget");
			 target.transform.parent = imageTarget.transform;
		 }
	}
}
