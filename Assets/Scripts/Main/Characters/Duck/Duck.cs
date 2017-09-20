using UnityEngine;

namespace Unorthoducks
{
  [RequireComponent(typeof(AudioSource))]
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
      randPoint = locationFinder.RandomLocation(0.2f, 75f);
    }

    public void Update ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      GameObject closestZombie = objectFinder.GetClosestObject("Zombie", transform.position, 2f);
      bool escapingZombie = closestZombie ? true : false;
      float speed = 0.5f;
      GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
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
      if(escapingZombie) return -0.5f;
      else return 0.4f;
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
      AudioSource[] sounds = newZombie.GetComponents<AudioSource>();
      sounds[0].Play();
    }
  }
}
