using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class GameOverText : MonoBehaviour {

		public Text finalScore;

		void Start () {
			finalScore.text = "Gameover! You scored: " + ScoreManager.Score().ToString ();
		}

		void Update () {

		}
	}
}
