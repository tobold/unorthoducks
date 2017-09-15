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

    public void Move ()
    {
      float speed = 1;
      float step = speed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, GetClosestEnemy(ducks).transform.position, step);
    }

    public void FindEnemies ()
    {
      ducks = GameObject.FindGameObjectsWithTag("Duck");
    }

    private GameObject GetClosestEnemy(GameObject[] enemies)
    {
      GameObject dMin = null;
      float minDist = Mathf.Infinity;
      Vector3 currentPos = transform.position;
      foreach (GameObject d in enemies)
      {
         float dist = Vector3.Distance(d.transform.position, currentPos);
         if (dist < minDist)
         {
             dMin = d;
             minDist = dist;
         }
      }
      return dMin;
    }
	}
}
