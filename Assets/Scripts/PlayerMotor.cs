using UnityEngine;
namespace UnityTest
{
  public class PlayerMotor : MonoBehaviour
  {
    // public Projectile projectile;
    // public PlayerController controller;

    public void Update()
    {
      if (Input.GetMouseButtonDown(0))
  				Fire ();
    }

    public void Fire()
    {
      GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      sphere.AddComponent<Rigidbody>();
      Vector3 startvelocity = Camera.main.transform.forward;
      startvelocity = startvelocity.normalized * 20;
      sphere.GetComponent<Rigidbody> ().velocity = startvelocity;
      sphere.transform.position = Camera.main.transform.position;
      sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
  }
}
