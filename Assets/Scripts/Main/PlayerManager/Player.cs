using UnityEngine;

namespace Unorthoducks
{
  public class Player : MonoBehaviour, IGunController
  {
    public Projectile projectile;
    public PlayerController controller;
    public GameObject spawnPoint;
    public GameObject turret;
	public Animator anim;
	private bool turretshoot;

		void start ()
		{
			turretshoot = false;
			anim = GetComponent<Animator> ();
		}

    private void OnEnable ()
		{
			controller.SetGunController (this);
		}

    private void Update()
    {
			if (Input.GetMouseButtonDown (0)) {
				controller.ApplyFire ();
				anim.SetBool ("turretshoot", true);
			} else {
				anim.SetBool ("turretshoot", false);
			}
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
