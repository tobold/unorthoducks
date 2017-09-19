using System;
using UnityEngine;

namespace Unorthoducks
{
	public class GameObjectFinder : MonoBehaviour
	{
    public GameObject[] FindObjects (string tag)
    {
      return GameObject.FindGameObjectsWithTag(tag);
    }

    public GameObject GetClosestObject(string tag, Vector3 objectPosition, float minDistance)
    {
      GameObject closestObject = null;
      foreach (GameObject gameObject in FindObjects(tag))
      {
        if (gameObject)
        {
          float dist = Vector3.Distance(gameObject.transform.position, objectPosition);
          if (dist < minDistance)
          {
            closestObject = gameObject;
            minDistance = dist;
          }
        }
      }
      return closestObject;
    }
  }
}
