using System;

namespace Unorthoducks
{
	public class Settings
	{
		public const int duckCount = 8;
		public const int size = 5;
		public const float roundLength = 15f;
		public const float initialSpawnRate = 3f;

		public static int LandscapeSize ()
		{
			return size;
		}

		public static int GetInitialDuckCount ()
		{
			return duckCount;
		}

		public static float GetInitialSpawnRate ()
		{
			return initialSpawnRate;
		}

		public static float RoundLength ()
		{
			return roundLength;
		}
	}
}
