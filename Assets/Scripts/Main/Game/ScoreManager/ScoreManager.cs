using System;
using System.Collections.Generic;

namespace Unorthoducks
{
	public class ScoreManager
	{
		private static int score = 0;
		private static List<int> allScores = new List<int>();
		private static int bonusPoints = 0;

		public static void ZombieKill ()
		{
			score += 5;
			GameManager.IncrementZombieKillCount();
		}

		public static void DuckKill ()
		{
			score -= 10;
			GameManager.IncrementDeadDucks();
		}

		public static void AddDuckSurvivalBonus ()
		{
			int liveDucks = GameManager.RemainingDucks();
			bonusPoints = liveDucks * 10;
			score += bonusPoints;
		}

		public static int DuckSurvivalBonus ()
		{
			return bonusPoints;
		}

		public static void ZombieBiteDuck ()
		{
			GameManager.IncrementBittenDuck();
		}

		public static int Score()
		{
			return score;
		}

		public static void SaveScore()
		{
			allScores.Add(score);
			ResetScore();
		}

		public static void ResetScore()
		{
			score = 0;
		}

		public static List<int> AllScores()
		{
			return allScores;
		}
	}
}
