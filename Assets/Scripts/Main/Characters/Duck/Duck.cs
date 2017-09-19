using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public GameObjectFinder objectFinder;
    public BoardLocationFinder locationFinder;
    public DuckController duckController;
    public Zombie zombie;
    private bool eliminated;
    public Vector3 randPoint;

    public void Start ()
    {
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
      randPoint = locationFinder.RandomLocation(0.2f);
    }

    public void Update ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      GameObject closestZombie = objectFinder.GetClosestObject("Zombie", transform.position, 2f);
      bool escapingZombie = closestZombie ? true : false;
      transform.position = Vector3.MoveTowards(transform.position,
                                               ChooseDirection(closestZombie),
                                               ChooseSpeed(escapingZombie) * Time.deltaTime);
      transform.rotation = Quaternion.Slerp(transform.rotation, GetRotation(closestZombie), 0.2F);
    }

    private Quaternion GetRotation(GameObject closestZombie)
    {
      if(closestZombie) {
        return Quaternion.LookRotation(transform.position - closestZombie.transform.position);
      }
      return Quaternion.LookRotation(randPoint);
    }

    private float ChooseSpeed(bool escapingZombie)
    {
      if(escapingZombie) return -0.3f;
      else return 0.5f;
    }

    private Vector3 ChooseDirection(GameObject closestZombie)
    {
      if(closestZombie) return closestZombie.transform.position;
      else return randPoint;
    }

    void OnCollisionEnter (Collision col)
    {
      if (col.gameObject.tag == "Projectile" && !eliminated) {
        eliminated = true;
        ScoreManager.DuckKill();
        Destroy (this.gameObject);
      } else if(col.gameObject.tag == "Zombie" && !eliminated) {
        eliminated = true;
        ScoreManager.ZombieBiteDuck();
        Destroy (this.gameObject);
        TransformToZombie(transform.position);
      } else if(col.gameObject.tag == "Edge") {
        ChangeDirection();
      }
    }

    void TransformToZombie (Vector3 position)
    {
      var newZombie = Instantiate(zombie, position, Quaternion.identity) as Zombie;
      newZombie.transform.parent = transform.parent;
    }
  }
}
