using UnityEngine;

namespace Unorthoducks
{
	public class BoardLocationFinder : MonoBehaviour
	{
    private int boardSize;
    // private Vector3 randPoint;

    public void Start ()
    {
      boardSize = Settings.LandscapeSize();
    }

    public Vector3 RandomLocation (float elevation)
    {
      var x = Random.Range(-boardSize/2f, boardSize/2f);
      var z = Random.Range(-boardSize/2f, boardSize/2f);
      return new Vector3(x, elevation, z);
    }
  }
}
