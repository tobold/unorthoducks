using UnityEngine;

namespace Unorthoducks
{
	public class Landscape : MonoBehaviour
	{
    public GameObject landscape;
    public int size;

    public void OnEnable ()
    {
      var floor = Instantiate (landscape, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
      Resize (floor);
      GameObject imageTarget = GameObject.Find("ImageTarget");
      floor.transform.parent = imageTarget.transform;
    }

    public void Resize (GameObject floor)
    {
      var x = 1 * size;
      var y = 1 * size;
      floor.transform.localScale += new Vector3(x, 0, y);
    }
  }
}
