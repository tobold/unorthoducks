using UnityEngine;

namespace Unorthoducks
{
	public class BoardLocationFinder : MonoBehaviour
	{
		public int boardSize;

    public Vector3 RandomLocation (float elevation, float percentageOfArea)
    {
			float roamRange = RoamRange(percentageOfArea);
      var x = Random.Range(-roamRange, roamRange);
      var z = Random.Range(-roamRange, roamRange);
      return new Vector3(x, elevation, z);
    }

		public float RoamRange(float percentageOfArea)
		{
			boardSize = Settings.LandscapeSize();
			return boardSize * percentageOfArea / ( 100 * 2 );
		}

		public bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
		{
			bool equal = true;
			if (Mathf.Abs (v1.x - v2.x) > precision) equal = false;
			if (Mathf.Abs (v1.z - v2.z) > precision) equal = false;
			return equal;
		}
  }
}
