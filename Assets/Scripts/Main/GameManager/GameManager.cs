using System;

namespace Unorthoducks
{
	public class GameManager
	{
    private static int zombieKillCount = 0;

		public static void IncrementZombieKillCount()
		{
			zombieKillCount += 1;
		}

		public static int ZombieKillCount ()
		{
			return zombieKillCount;
		}
	}
}
