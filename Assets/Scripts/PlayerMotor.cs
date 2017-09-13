using UnityEngine;

namespace Unorthoducks
{
  public class PlayerMotor : MonoBehaviour, IGunController
  {
    public GameObject projectile;
    public GameObject playerposition;
    public PlayerController controller;

    private void OnEnable ()
		{
			controller.SetGunController (this);
		}

    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
  				controller.ApplyFire ();
    }

    public void Fire()
    {
      var bullet = Instantiate (projectile, Camera.main.transform.position,
				Quaternion.identity) as GameObject;

      Vector3 startvelocity = Camera.main.transform.forward;
      startvelocity = startvelocity.normalized * 20;

      bullet.GetComponent<Rigidbody> ().velocity = startvelocity;

      // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      // sphere.AddComponent<Rigidbody>();
      // Vector3 startvelocity = Camera.main.transform.forward;
      // startvelocity = startvelocity.normalized * 20;
      // sphere.GetComponent<Rigidbody> ().velocity = startvelocity;
      // sphere.transform.position = Camera.main.transform.position;
      // sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
  }
}
