using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unorthoducks
{
	public class GameOverText : MonoBehaviour {
		public Text finalScore;
		public Text allScores;
		List<int> allScoresList = new List<int>();

	  void Start () {
			var score = ScoreManager.Score().ToString();
	    finalScore.text = "Gameover! You scored: " + score;
			PrintScoreHistory();
			ScoreManager.SaveScore();
	  }

		void PrintScoreHistory () {
			var scores = "";
			allScoresList = ScoreManager.AllScores();
			foreach(int element in allScoresList)
				{
					scores += element.ToString() + ". ";
				}
				if (scores != ""){
					allScores.text = "Your previous scores: " + scores;
				}
		}

	}
}
