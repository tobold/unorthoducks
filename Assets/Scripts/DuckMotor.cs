using UnityEngine;

namespace Unorthoducks
{
	public class DuckMotor : MonoBehaviour, IDuckController
	{
		public Duck duck;
		public DuckController controller;

		public void OnEnable ()
		{
			controller.SetDuckController (this);
			controller.Initialise ();
		 }

		 public void Initialise ()
		 {
			 var target = Instantiate (duck, new Vector3(3f, 0.15f, 6f),
					Quaternion.identity) as Duck;
					GameObject imageTarget = GameObject.Find("ImageTarget");
					target.transform.parent = imageTarget.transform;
					this.Move (target);
		 }

			private void Move (Duck target)
			{
				Vector3 randomDirection = new Vector3(Random.Range(-1, 2), 0.0f, Random.Range(-1, 2));
	         target.GetComponent<Rigidbody> ().velocity = randomDirection * 1f;
			}
		}
}
