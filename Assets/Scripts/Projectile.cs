using UnityEngine;

namespace Unorthoducks
{
  public class Projectile : MonoBehaviour
  {
    float Floor = -20;

    void Update () {
		  if (this.transform.position.y < Floor) Destroy (this.gameObject);
    }
    
    void OnCollisionEnter(Collision collision)
    {
      Destroy (this.gameObject);
    }
  }
}
