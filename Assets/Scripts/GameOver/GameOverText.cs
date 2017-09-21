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
			ScoreManager.SaveScore();
			PrintScoreHistory();
	  }

		void PrintScoreHistory () {
			var scores = "";
			allScoresList = ScoreManager.AllScores();
			allScoresList.Sort();
			allScoresList.Reverse();
			foreach(int element in allScoresList){
					scores += element.ToString() + "$";
			}
				if (scores != ""){
					allScores.text = "Top scores: " + "$" + scores;
					allScores.text = allScores.text.Replace('$','\n');
			}
		}
	}
}
