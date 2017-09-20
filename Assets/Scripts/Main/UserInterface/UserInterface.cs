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
		public Image textPanel;
		private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 3.0f;
		private bool showText;

		public void Update ()
		{
			scoreText.text = ScoreManager.Score().ToString ();
			roundText.text = "Round " + GameManager.RoundNumber().ToString ();
			CheckRoundOver();
			if(showText) ShowRound();
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
				}
			}
		}

		public void ShowRound ()
		{
			textPanel.gameObject.SetActive(true);
			largeRoundText.text = "NEXT";
		}

		public void HideRound ()
		{
			textPanel.gameObject.SetActive(false);
		}
	}
}
