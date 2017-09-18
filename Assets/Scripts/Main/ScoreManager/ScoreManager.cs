using System;

namespace Unorthoducks
{
	public class ScoreManager
	{
    private static int score = 0;

		public static void ZombieKill ()
		{
			score += 5;
			GameManager.IncrementZombieKillCount();
		}

		public static void DuckKill ()
		{
			score -= 10;
		}

    public static int Score()
    {
      return score;
    }
	}
}
