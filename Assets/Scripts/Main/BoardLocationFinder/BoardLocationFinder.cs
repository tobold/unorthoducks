using UnityEngine;

namespace Unorthoducks
{
	public class BoardLocationFinder : MonoBehaviour
	{
    public Vector3 RandomLocation (float elevation, float percentageOfArea)
    {
			int boardSize = Settings.LandscapeSize();
			float roamRange = boardSize / ( ( percentageOfArea / 100 ) * 2 );
      var x = Random.Range(-roamRange, roamRange);
      var z = Random.Range(-roamRange, roamRange);
      return new Vector3(x, elevation, z);
    }
  }
}
