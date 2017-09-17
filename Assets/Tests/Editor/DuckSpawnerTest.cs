using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class DuckSpawnerControllerTests
  {
    private ISpawner duckSpawner;
    private DuckSpawnerController controller;

    [SetUp]
    public void BeforeTest ()
    {
      duckSpawner = GetDuckSpawnerMock ();
      controller = new DuckSpawnerController ();
      controller.SetDuckSpawner (duckSpawner);
    }

    [Test]
    public void Spawn ()
    {
      controller.Spawn ();
      duckSpawner.Received (1).Spawn ();
    }

    private ISpawner GetDuckSpawnerMock ()
    {
      return Substitute.For<ISpawner> ();
    }
  }
}
