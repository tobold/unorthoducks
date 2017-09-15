using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour, IDuckMovementController
  {
    public DuckController duckController;

    private void OnEnable ()
    {
      duckController.SetDuckMovementController (this);
    }

    public void Update ()
    {
      duckController.Move();
    }

    public void Move ()
    {
      Vector3 randomDirection = new Vector3(Random.Range(-1, 2), 0.0f, Random.Range(-1, 2));
      GetComponent<Rigidbody> ().velocity = randomDirection * 1f;
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
