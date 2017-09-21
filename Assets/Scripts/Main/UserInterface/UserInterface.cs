using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class UserInterface : MonoBehaviour
	{
    public Text scoreText;
		public Text roundText;
		public Text largeRoundText;
		public Text bonusPointsText;
		public Image textPanel;
		private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 3.0f;
		private bool showText;

		public void Update ()
		{
			scoreText.text = ScoreManager.Score().ToString ();
			roundText.text = "Round " + RoundNumber();
			CheckRoundOver();
			if(showText) {
				ShowRound();
				ShowBonusPoints();
			}
		}

		public void CheckRoundOver ()
		{
			currentTime = Time.time;
			if(GameManager.LevelComplete()) {
				executedTime = Time.time;
				showText = true;
			}
			if(executedTime != 0.0f)
			{
				if(currentTime - executedTime > timeToWait)
				{
					executedTime = 0.0f;
					showText = false;
					HideRound();
					HideBonusPoints();
				}
			}
		}

		public void ShowRound ()
		{
			textPanel.gameObject.SetActive(true);
			largeRoundText.text = "ROUND " + RoundNumber();
			bonusPointsText.text = "+ " + BonusPoints();
		}

		public void HideRound ()
		{
			textPanel.gameObject.SetActive(false);
			bonusPointsText.text = "";
		}

		public void ShowBonusPoints ()
		{
			bonusPointsText.text = "+ " + BonusPoints();
		}

		public void HideBonusPoints ()
		{
			bonusPointsText.text = "";
		}

		public string RoundNumber ()
		{
			return GameManager.RoundNumber().ToString ();
		}

		public int BonusPoints ()
		{
			return ScoreManager.DuckSurvivalBonus();
		}
	}
}
