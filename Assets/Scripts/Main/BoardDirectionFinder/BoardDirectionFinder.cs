using UnityEngine;

namespace Unorthoducks
{
	public class BoardDirectionFinder : MonoBehaviour
	{
    public Vector3 Forwards (Transform myTransform, float speed)
    {
			return myTransform.position + (myTransform.forward * Time.deltaTime * speed);
    }

    public Vector3 Towards(Transform myTransform, Vector3 newLocation, float speed)
    {
      Vector3 movePosition = myTransform.position;
      movePosition.x = Mathf.MoveTowards(myTransform.position.x, newLocation.x, speed * Time.deltaTime);
      movePosition.z = Mathf.MoveTowards(myTransform.position.z, newLocation.z, speed * Time.deltaTime);
      return movePosition;
    }
  }
}
