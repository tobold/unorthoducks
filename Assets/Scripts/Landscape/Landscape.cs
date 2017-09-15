using UnityEngine;

namespace Unorthoducks
{
	public class Landscape : MonoBehaviour, ILandscapeController
	{
    public LandscapeController landscapeController;
    public GameObject landscape;
    public int size;

    public void OnEnable ()
    {
			size = Settings.LandscapeSize();
      landscapeController.SetLandscapeController (this);
      landscapeController.Initialise();
    }

    private void Resize (GameObject floor)
    {
      var x = 1 * size;
      var y = 1 * size;
      floor.transform.localScale += new Vector3(x, 0, y);
    }

    public int CheckSize ()
    {
      return size;
    }

    public void Initialise ()
    {
      var floor = Instantiate (landscape, new Vector3(0, 0.05f, 0), Quaternion.identity) as GameObject;
      Resize (floor);
      GameObject imageTarget = GameObject.Find("ImageTarget");
      floor.transform.parent = imageTarget.transform;
    }
  }
}
