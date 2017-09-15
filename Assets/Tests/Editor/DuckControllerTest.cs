using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class DuckControllerTests
  {
    private IDuckMovementController duckMovementController;
    private DuckController controller;

    [SetUp]
    public void BeforeTest ()
    {
      duckMovementController = GetDuckMovementControllerMock ();
      controller = new DuckController ();
      controller.SetDuckMovementController (duckMovementController);
    }

    [Test]
    public void Move ()
    {
      controller.Move ();
      duckMovementController.Received (1).Move ();
    }

    [Test]
    public void Direction ()
    {
      controller.Direction ();
      duckMovementController.Received (1).Direction ();
    }

    private IDuckMovementController GetDuckMovementControllerMock ()
    {
      return Substitute.For<IDuckMovementController> ();
    }
  }
}
