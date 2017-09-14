using UnityEngine;

namespace Unorthoducks
{
  public class Duck : MonoBehaviour
  {
    void OnCollisionEnter (Collision col)
    {
      if(col.gameObject.name == "pref_projectile(Clone)")
      {
        Destroy (this.gameObject);
      }
    }
  }
}
