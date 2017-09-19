using UnityEngine;

namespace Unorthoducks
{
  public class Player : MonoBehaviour, IGunController
  {
    public Projectile projectile;
    public PlayerController controller;
    public GameObject spawnPoint;
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
      Transform t = spawnPoint.transform;
      Vector3 bulletExit = t.position;
      Vector3 bulletVelocity = new Vector3((float)t.up.x, (float)t.up.y, (float)t.up.z);

      var bullet = Instantiate (projectile, bulletExit,
				Quaternion.LookRotation(turret.transform.up)) as Projectile;
      bullet.transform.parent = turret.transform;
      bullet.GetComponent<Rigidbody> ().velocity = bulletVelocity * 20;
    }
  }
}
