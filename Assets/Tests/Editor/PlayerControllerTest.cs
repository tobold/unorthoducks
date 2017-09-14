using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class PlayerControllerTests
  {
    private IGunController gunController;
    private PlayerController controller;

    [SetUp]
    public void BeforeTest ()
    {
      gunController = GetGunMock ();
      controller = new PlayerController ();
      controller.SetGunController (gunController);
    }

    [Test]
    public void FireWorks ()
    {
      controller.ApplyFire ();
      gunController.Received (1).Fire ();
    }

    [Test]
    public void MultipleFireWorks ()
    {
      int amountOfFires = 3;
      for(int i = 0; i < amountOfFires; i ++)
      {
        controller.ApplyFire ();
      }
      gunController.Received (amountOfFires).Fire ();
    }

    private IGunController GetGunMock ()
    {
      return Substitute.For<IGunController> ();
    }
  }
}
