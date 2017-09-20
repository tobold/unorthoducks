using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class GameOverText : MonoBehaviour {
		public Text finalScore;
		public Text allScores;

	  void Start () {
	    ScoreManager.SaveScore();
	    finalScore.text = "Gameover! You scored: " + ScoreManager.Score().ToString ();
	    allScores.text = "Your previous scores: " + ScoreManager.AllScores()[0].ToString ();
	  }

		void Update () {

		}
	}
}
