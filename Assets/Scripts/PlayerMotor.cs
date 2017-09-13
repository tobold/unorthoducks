using UnityEngine;

namespace Unorthoducks
{
  public class PlayerMotor : MonoBehaviour, IGunController
  {
    public Projectile projectile;
    public Transform cam;
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
      cam = Camera.main.transform;
      var bullet = Instantiate (projectile, cam.position,
				Quaternion.identity) as Projectile;
      Vector3 startvelocity = cam.forward.normalized * 20;
      bullet.GetComponent<Rigidbody> ().velocity = startvelocity;
    }
  }
}
