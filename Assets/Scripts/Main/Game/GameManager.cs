using System;

namespace Unorthoducks
{
	public class GameManager
	{
		// hardcoded!
		private static int zombiesToKill = 1;
		private static int ducks = 8;

		private static int zombieKillCount = 0;
		private static int deadDucks = 0;

		public static void IncrementZombieKillCount()
		{
			zombieKillCount += 1;
		}

		public static void IncrementDeadDucks()
		{
			deadDucks += 1;
		}

		public static void IncrementBittenDuck()
		{
			deadDucks += 1;
			zombiesToKill += 1;
		}

		public static int DeadDucks()
		{
			return deadDucks;
		}

		public static int ZombieKillCount ()
		{
			return zombieKillCount;
		}

		public static bool IsGameOver()
		{
			if(deadDucks >= ducks) {
				return true;
			} else return false;
		}

		public static bool LevelUp()
		{
			if(zombieKillCount >= 0) {
				return true;
			} else return false;
		}
	}
}
