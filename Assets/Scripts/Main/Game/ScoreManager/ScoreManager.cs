using System;

namespace Unorthoducks
{
	[Serializable]
	public class ScoreManager
	{
    public int score = 0;

		public void ZombieKill ()
		{
			score += 5;
			GameManager.IncrementZombieKillCount();
		}

		public void DuckKill ()
		{
			score -= 10;
			GameManager.IncrementDeadDucks();
		}

		public void ZombieBiteDuck ()
		{
			GameManager.IncrementBittenDuck();
		}

    public int Score()
    {
      return score;
    }
	}
}
