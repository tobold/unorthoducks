using NSubstitute;
using NUnit.Framework;

namespace Unorthoducks
{
  public class ZombieSpawnerControllerTests
  {
    private ISpawner zombieSpawner;
    private ZombieSpawnerController controller;

    [SetUp]
    public void BeforeTest ()
    {
      zombieSpawner = GetZombieSpawnerMock ();
      controller = new ZombieSpawnerController ();
      controller.SetZombieSpawner (zombieSpawner);
    }

    [Test]
    public void SpawnWorks ()
    {
      controller.Spawn ();
      zombieSpawner.Received (1).Spawn ();
    }

    private ISpawner GetZombieSpawnerMock ()
    {
      return Substitute.For<ISpawner> ();
    }
  }
}
