using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public GameObject[] zombies;
    public DuckController duckController;
	  public int boardSize;
    public Vector3 randPoint;
    public Zombie zombie;

    public void Start ()
     {
       boardSize = Settings.LandscapeSize ();
       duckController.SetDuckMovementController (this);
       float randomTime = Random.Range(1f, 5f);
       InvokeRepeating("ChangeDirection", 0f, randomTime);
     }

     public void ChangeDirection()
     {
         duckController.Direction();
     }

    public void Direction ()
    {
      var x = Random.Range(-boardSize/2f, boardSize/2f);
      var z = Random.Range(-boardSize/2f, boardSize/2f);
      randPoint = new Vector3(x, 0.125f, z);
    }

    public void Update ()
    {
      FindEnemies();
      duckController.Move();
    }

    public void FindEnemies ()
    {
      zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    public void Move ()
    {
      GameObject closestZombie = GetClosestEnemy(zombies);
      if (closestZombie == null)
      {
        float step = 0.5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randPoint, step);
      }
      else
      {
        float step = -0.3f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, closestZombie.transform.position, step);
      }
    }

    void OnCollisionEnter (Collision col)
    {
      if (col.gameObject.name == "pref_projectile(Clone)") {
        Destroy (this.gameObject);
      }
      if(col.gameObject.name == "pref_zombie(Clone)")
      {
        Destroy (this.gameObject);
        TransformToZombie(transform.position);
      }
    }

    void TransformToZombie (Vector3 position)
    {
      var newZombie = Instantiate(zombie, position, Quaternion.identity) as Zombie;
      newZombie.transform.parent = transform.parent;
    }

    private GameObject GetClosestEnemy(GameObject[] enemies)
    {
      GameObject zombieMin = null;
      float minDist = 1;
      Vector3 currentPos = transform.position;
      foreach (GameObject zombie in enemies)
      {
				if (zombie)
				{
					float dist = Vector3.Distance(zombie.transform.position, currentPos);
					if (dist < minDist)
					{
					  zombieMin = zombie;
					  minDist = dist;
					}
				}
      }
      return zombieMin;
    }
  }
}
