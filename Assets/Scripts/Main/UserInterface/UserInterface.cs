using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class UserInterface : MonoBehaviour
	{
    public Text scoreText;
		public Text roundText;

		public void Update ()
		{
			scoreText.text = "SCORE: " + ScoreManager.Score().ToString ();
			roundText.text = "Round " + GameManager.RoundNumber().ToString ();
		}
	}
}
