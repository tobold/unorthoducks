using UnityEngine;

namespace Unorthoducks
{
  public class PlayerMotor : MonoBehaviour, IGunController
  {
    public Projectile projectile;
    public PlayerController controller;
    public GameObject turret;

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
      Transform t = turret.transform;
      Vector3 bulletExit = new Vector3((float)t.position.x, (float)t.position.y, (float)t.position.z);
      Vector3 bulletVelocity = new Vector3((float)t.up.x, (float)t.up.y, (float)t.up.z);

      var bullet = Instantiate (projectile, bulletExit,
				Quaternion.identity) as Projectile;
      bullet.GetComponent<Rigidbody> ().velocity = bulletVelocity * 20;
    }
  }
}
