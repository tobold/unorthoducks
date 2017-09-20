using UnityEngine;

namespace Unorthoducks
{
  [RequireComponent(typeof(AudioSource))]
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public GameObjectFinder objectFinder;
    public BoardLocationFinder locationFinder;
    public BoardDirectionFinder directionFinder;
    public DuckController duckController;
    public Zombie zombie;
    public float duckSpeed;
    private bool eliminated;
    public Vector3 randPoint;
    private float lastUpdate = 0.0f, currentTime = 0.0f, timeToWait = 0.5f;

    public void Start ()
    {
      duckSpeed = 0.5f;
      duckController.SetDuckMovementController (this);
      ChangeDirection();
      float randomQuackTime = Random.Range(1f, 6f);
      Invoke("Quack", randomQuackTime);
    }

    public void Quack ()
    {
      AudioSource[] sounds = GetComponents<AudioSource>();
      int randomSample = Random.Range(0, 2);
      sounds[randomSample].Play();
      float randomQuackTime = Random.Range(5f, 10f);
      Invoke("Quack", randomQuackTime);
    }

    public void ChangeDirection()
    {
      duckController.Direction();
    }

    public void Direction ()
    {
      currentTime = Time.time;
      if(currentTime - lastUpdate > timeToWait)
      {
        randPoint = locationFinder.RandomLocation(0.2f, 65f);
        lastUpdate = Time.time;
      }
    }

    public void FixedUpdate ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      GameObject closestZombie = objectFinder.GetClosestObject("Zombie", transform.position, 1f);
      Vector3 movePosition;
      if(closestZombie == null) {
        movePosition = directionFinder.Towards(transform, randPoint, duckSpeed);
        if(locationFinder.AlmostEqual(transform.position, randPoint, 0.1f)) ChangeDirection();
      } else {
        movePosition = directionFinder.Forwards(transform, duckSpeed);
      }
      GetComponent<Rigidbody>().MovePosition(movePosition);
      transform.rotation = Quaternion.Slerp(transform.rotation, GetRotation(closestZombie), 0.5f);
    }

    private Quaternion GetRotation(GameObject closestZombie)
    {
      if(closestZombie) {
        return Quaternion.LookRotation(transform.position - closestZombie.transform.position);
      }
      return Quaternion.LookRotation(randPoint - transform.position);
    }

    void OnCollisionEnter (Collision col)
    {
      if (col.gameObject.tag == "Projectile" && !eliminated) {
        ScoreManager.DuckKill();
        KillDuck();
      } else if(col.gameObject.tag == "Zombie" && !eliminated) {
        ScoreManager.ZombieBiteDuck();
        KillDuck();
        TransformToZombie(transform.position);
      } else if(col.gameObject.tag == "Duck") {
        ChangeDirection();
      }
    }

    void KillDuck()
    {
      eliminated = true;
      Destroy (this.gameObject);
    }

    void TransformToZombie (Vector3 position)
    {
      var newZombie = Instantiate(zombie, position, Quaternion.identity) as Zombie;
      newZombie.transform.parent = transform.parent;
      AudioSource[] sounds = newZombie.GetComponents<AudioSource>();
      sounds[0].Play();
    }
  }
}
