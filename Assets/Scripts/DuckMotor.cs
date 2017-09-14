using UnityEngine;

namespace Unorthoducks
{
	public class DuckMotor : MonoBehaviour, IDuckController
	{
		public Duck duck;

		public void Start ()
		{
			var target = Instantiate (duck, new Vector3(3f, 0.15f, 6f),
				Quaternion.identity) as Duck;
				GameObject imageTarget = GameObject.Find("ImageTarget");
				target.transform.parent = imageTarget.transform;
		 }
	}
}
