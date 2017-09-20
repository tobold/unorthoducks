using System;

namespace Unorthoducks
{
	public class GameManager
	{
		private static int roundNumber = 0;
		private static int deadDucks = 0;

		private static int ducks = Settings.GetInitialDuckCount();
		private static float initialSpawnRate = Settings.GetInitialSpawnRate();
		private static float roundLength = Settings.RoundLength();

		private static float zombiesToKill;
		private static int zombieKillCount;
		private static float spawnRate;

		public static void Restart()
		{
			roundNumber = 0;
			deadDucks = 0;
		}

		public static void BeginRound()
		{
			zombieKillCount = 0;
			spawnRate = initialSpawnRate * (float)(Math.Pow(0.85, roundNumber));
			zombiesToKill = GetZombiesToSpawn();
		}

		public static void EndRound()
		{
			roundNumber ++;
			BeginRound();
		}

		public static float GetZombiesToSpawn()
		{
			return (roundLength / spawnRate);
		}

		public static float GetSpawnRate()
		{
			return spawnRate;
		}

		public static int RoundNumber()
		{
			return roundNumber + 1;
		}

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

		public static bool LevelComplete()
		{
			if(zombiesToKill > 0 && zombieKillCount >= zombiesToKill) {
				return true;
			} else return false;
		}
	}
}
