using UnityEngine;

namespace Unorthoducks
{
	public class Zombie : MonoBehaviour, IDuckMovementController
	{
    public GameObject[] ducks;
    public ZombieController zombieController;
		public Vector3 direction;

    private void OnEnable ()
		{
			zombieController.SetMovementController (this);
			zombieController.FindEnemies();
		}

    public void FixedUpdate ()
		{
			Direction();
	        zombieController.Move();
	    }

		public void Direction ()
		{
			GameObject chasedDuck = GetClosestEnemy(ducks);
			direction = (chasedDuck.transform.position - transform.position).normalized;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15F);
		}

    public void Move ()
    {
			float speed = 1f;
		GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
    }

    public void FindEnemies ()
    {
      ducks = GameObject.FindGameObjectsWithTag("Duck");
    }

		void OnCollisionEnter (Collision col)
    {
      zombieController.FindEnemies();

			if(col.gameObject.tag == "Projectile")
      {
        Destroy (this.gameObject);
      }
    }

    private GameObject GetClosestEnemy(GameObject[] enemies)
    {
      GameObject dMin = null;
      float minDist = Mathf.Infinity;
      Vector3 currentPos = transform.position;
      foreach (GameObject d in enemies)
      {
				if (d)
				{
					float dist = Vector3.Distance(d.transform.position, currentPos);
					if (dist < minDist)
					{
					  dMin = d;
					  minDist = dist;
					}
				}
      }
      return dMin;
    }
	}
}
