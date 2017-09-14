using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class ZombieControllerTests
  {
    private IZombieMovementController zombieMovementController;
    private ZombieController controller;

    [SetUp]
    public void BeforeTest ()
    {
      zombieMovementController = GetZombieMovementMock ();
      controller = new ZombieController ();
      controller.SetZombieMovementController (zombieMovementController);
    }

    [Test]
    public void MoveWorks ()
    {
      controller.Move ();
      zombieMovementController.Received (1).Move ();
    }

    private IZombieMovementController GetZombieMovementMock ()
    {
      return Substitute.For<IZombieMovementController> ();
    }
  }
}
