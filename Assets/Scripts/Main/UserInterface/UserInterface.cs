using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class UserInterface : MonoBehaviour
	{
    public Text scoreText;
		public ScoreManager scoreManager;

		public void Update ()
		{
			scoreText.text = "SCORE: " + scoreManager.Score().ToString ();
		}
	}
}
