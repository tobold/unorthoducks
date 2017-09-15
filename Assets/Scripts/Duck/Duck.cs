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
      Invoke("ControllerDirection", 0f);
    }

    public void ControllerDirection()
    {
        float randomTime = Random.Range(1f, 5f);
        duckController.Direction();
        Invoke("ControllerDirection", randomTime);
    }

    public void Direction ()
    {
      var x = Random.Range(-boardSize/2f, boardSize/2f);
      var y = Random.Range(-boardSize/2f, boardSize/2f);
      randPoint = new Vector3(x, 0.125f, y);
    }

    public void FindEnemies ()
    {
      zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    public void Update ()
    {
      FindEnemies();
      duckController.Move();
    }

    public void Move ()
    {
      GameObject closestZombie = GetClosestEnemy(zombies);
      if (closestZombie == null)
      {
        float speed = 0.5f;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randPoint, step);
      }
      else
      {
        float speed = -0.3f;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, closestZombie.transform.position, step);
      }
    }

    void OnCollisionEnter (Collision col)
    {
      if(col.gameObject.name == "pref_projectile(Clone)")
      {
        Destroy (this.gameObject);
      }

      if(col.gameObject.name == "pref_zombie(Clone)")
      {
        Vector3 position = transform.position;
        Destroy (this.gameObject);
        var newZombie = Instantiate(zombie, position, Quaternion.identity) as Zombie;
        newZombie.transform.parent = transform.parent;
        Debug.Log(newZombie);
      }
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
