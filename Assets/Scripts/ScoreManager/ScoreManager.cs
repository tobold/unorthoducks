using System;

namespace Unorthoducks
{
	public class ScoreManager
	{
    private static int score = 0;

		public static void ZombieKill ()
		{
			score += 5;
		}

    public static int Score()
    {
      return score;
    }
	}
}
