using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class GameOverText : MonoBehaviour {
		public ScoreManager scoreManager;
		public Text finalScore;

		void Start () {
			finalScore.text = "Gameover! You scored: " + scoreManager.Score().ToString ();
		}

		void Update () {

		}
	}
}
