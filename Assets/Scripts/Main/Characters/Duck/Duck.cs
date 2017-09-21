using UnityEngine;
using System.Collections.Generic;

namespace Unorthoducks
{
  [RequireComponent(typeof(AudioSource))]
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public GameObjectFinder objectFinder;
    public BoardLocationFinder locationFinder;
    public BoardDirectionFinder directionFinder;
    public DuckController duckController;
    public SoundManager soundManager;
    public Zombie zombie;
    public float duckSpeed;
    private bool eliminated, escapingZombie;
    public Vector3 randPoint;
    private Quaternion currentRotation;
    private float currentTime;
    private float lastRotationUpdate = 0.0f, escapeTime = 0.2f;
    private float lastDirectionUpdate = 0.0f, timeToWait = 0.5f;

    public void Start ()
    {
      duckSpeed = 0.5f;
      duckController.SetDuckMovementController (this);
      ChangeDirection();
      AudioSource[] sounds = GetComponents<AudioSource>();
      soundManager.InitialiseQuacks (sounds);
    }

    public void ChangeDirection()
    {
      duckController.Direction();
    }

    public void Direction ()
    {
      currentTime = Time.time;
      if(currentTime - lastDirectionUpdate > timeToWait)
      {
        randPoint = locationFinder.RandomLocation(0.2f, 65f);
        lastDirectionUpdate = currentTime;
      }
    }

    public void FixedUpdate ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      List<GameObject> closestZombies = objectFinder.GetClosestObjects("Zombie", transform.position, 1f);
      Vector3 movePosition;
      if(closestZombies.Count > 0) movePosition = directionFinder.Forwards(transform, duckSpeed);
      else {
        movePosition = directionFinder.Towards(transform, randPoint, duckSpeed);
        if(locationFinder.AlmostEqual(transform.position, randPoint, 0.1f)) ChangeDirection();
      }
      GetRotation(closestZombies);
      GetComponent<Rigidbody>().MovePosition(movePosition);
      transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, 0.5f);
    }

    private void GetRotation(List<GameObject> closestZombies)
    {
      currentTime = Time.time;
      if(currentTime - lastRotationUpdate > timeToWait) escapingZombie = false;
      if(escapingZombie) return;
      if(closestZombies.Count > 0) {
        escapingZombie = true;
        lastRotationUpdate = currentTime;
        Vector3 averagePosition = directionFinder.AveragePosition(closestZombies, transform);
        currentRotation = Quaternion.LookRotation(transform.position - averagePosition);
      } else {
        currentRotation = Quaternion.LookRotation(randPoint - transform.position);
      }
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
