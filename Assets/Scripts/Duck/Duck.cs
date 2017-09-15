using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public DuckController duckController;
	  public int size;
    public Vector3 randPoint;

    public void Start ()
    {
  	  size = Settings.LandscapeSize ();
      duckController.SetDuckMovementController (this);
      InvokeRepeating("ControllerDirection", 0f, 3f);
    }

    public void ControllerDirection()
    {
        duckController.Direction();
    }

    public void Direction ()
    {
      randPoint = new Vector3(Random.Range(-size/2f, size/2f), 0.125f, Random.Range(-size/2, size/2));
    }

    public void Update ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      float speed = 1;
      float step = speed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, randPoint, step);
    }

    void OnCollisionEnter (Collision col)
    {
      if(col.gameObject.name == "pref_projectile(Clone)")
      {
        Destroy (this.gameObject);
      }
    }
  }
}
