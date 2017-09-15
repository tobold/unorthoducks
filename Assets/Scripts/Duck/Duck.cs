using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public DuckController duckController;
	  public int size;

    public void OnEnable ()
    {
  	  size = Settings.LandscapeSize ();
      duckController.SetDuckMovementController (this);
    }

    public void Update ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      float speed = 1;
      float step = speed * Time.deltaTime;
      Vector3 randPoint = new Vector3(Random.Range(-size/2, size/2), 0f, Random.Range(-size/2, size/2));
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
