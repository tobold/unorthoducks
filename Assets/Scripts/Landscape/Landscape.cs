using UnityEngine;

namespace Unorthoducks
{
	public class Landscape : MonoBehaviour, ILandscapeController
	{
    public LandscapeController landscapeController;
    public GameObject landscape;
    public int boardSize;

    public void OnEnable ()
    {
			boardSize = Settings.LandscapeSize();
      landscapeController.SetLandscapeController (this);
      landscapeController.Initialise();
    }

    private void Resize (GameObject floor)
    {
      var x = boardSize;
      var y = boardSize;
      floor.transform.localScale = new Vector3((float)x, 0.1f, (float)y);
    }

    public void Initialise ()
    {
      var floor = Instantiate (landscape, new Vector3(0, -0.05f, 0),
			 Quaternion.identity) as GameObject;
      Resize (floor);
      GameObject imageTarget = GameObject.Find("ImageTarget");
      floor.transform.parent = imageTarget.transform;
    }
  }
}
