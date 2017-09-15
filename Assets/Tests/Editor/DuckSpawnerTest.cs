using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class DuckSpawnerControllerTests
  {
    private IDuckSpawner duckSpawner;
    private DuckSpawnerController controller;

    [SetUp]
    public void BeforeTest ()
    {
      duckSpawner = GetDuckSpawnerMock ();
      controller = new DuckSpawnerController ();
      controller.SetDuckSpawner (duckSpawner);
    }

    [Test]
    public void Initialise ()
    {
      controller.Initialise ();
      duckSpawner.Received (1).Initialise ();
    }

    private IDuckSpawner GetDuckSpawnerMock ()
    {
      return Substitute.For<IDuckSpawner> ();
    }
  }
}
