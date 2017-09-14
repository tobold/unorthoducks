using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class DuckControllerTests
  {
    private IDuckController duckController;
    private DuckController controller;

    [SetUp]
    public void BeforeTest ()
    {
      duckController = GetDuckMock ();
      controller = new DuckController ();
      controller.SetDuckController (duckController);
    }

    [Test]
    public void Initialise ()
    {
      controller.Initialise ();
      duckController.Received (1).Initialise ();
    }
    private IDuckController GetDuckMock ()
    {
      return Substitute.For<IDuckController> ();
    }
  }
}
