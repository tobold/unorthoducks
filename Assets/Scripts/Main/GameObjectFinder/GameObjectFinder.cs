using UnityEngine;
using System.Collections.Generic;

namespace Unorthoducks
{
	public class GameObjectFinder : MonoBehaviour
	{
    public GameObject[] FindObjects (string tag)
    {
      return GameObject.FindGameObjectsWithTag(tag);
    }

    public GameObject GetClosestObject(string tag, Vector3 myPosition, float minDistance)
    {
      GameObject closestObject = null;
      foreach (GameObject gameObject in FindObjects(tag))
      {
        if (gameObject)
        {
          float dist = Vector3.Distance(gameObject.transform.position, myPosition);
          if (dist < minDistance)
          {
            closestObject = gameObject;
            minDistance = dist;
          }
        }
      }
      return closestObject;
    }

		public List<GameObject> GetClosestObjects(string tag, Vector3 myPosition, float minDistance)
		{
			List<GameObject> closestObjects = new List<GameObject>();
			foreach (GameObject gameObject in FindObjects(tag))
      {
        if (gameObject)
        {
          float dist = Vector3.Distance(gameObject.transform.position, myPosition);
          if (dist < minDistance) closestObjects.Add(gameObject);
        }
      }
			return closestObjects;
		}
  }
}
