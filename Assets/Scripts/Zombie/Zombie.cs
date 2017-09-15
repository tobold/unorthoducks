using UnityEngine;

namespace Unorthoducks
{
	public class Zombie : MonoBehaviour, IDuckMovementController
	{
    public GameObject[] ducks;
    public ZombieController zombieController;

    private void OnEnable ()
		{
			zombieController.SetMovementController (this);
			zombieController.FindEnemies();
		}

    public void Update ()
		{
      zombieController.Move();
    }

		public void Direction ()
		{
    }

    public void Move ()
    {
      float speed = 0.5f;
      float step = speed * Time.deltaTime;
			GameObject chasedDuck = GetClosestEnemy(ducks);
      transform.position = Vector3.MoveTowards(transform.position, chasedDuck.transform.position, step);
    }

    public void FindEnemies ()
    {
      ducks = GameObject.FindGameObjectsWithTag("Duck");
    }

		void OnCollisionEnter (Collision col)
    {
      zombieController.FindEnemies();

			if(col.gameObject.name == "pref_projectile(Clone)")
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
