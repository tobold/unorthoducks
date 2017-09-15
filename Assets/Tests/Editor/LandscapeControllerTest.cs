using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class LandscapeControllerTests
  {
    private ILandscapeController landscapeController;
    private LandscapeController controller;

    [SetUp]
    public void BeforeTest ()
    {
      landscapeController = GetLandscapeControllerMock ();
      controller = new LandscapeController ();
      controller.SetLandscapeController (landscapeController);
    }

    [Test]
    public void Initialise ()
    {
      controller.Initialise ();
      landscapeController.Received (1).Initialise ();
    }
    private ILandscapeController GetLandscapeControllerMock ()
    {
      return Substitute.For<ILandscapeController> ();
    }
  }
}
