using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {

	public Button pauseButton;
  public Text buttonText;
  private bool running;

  public void Start () {
    running = true;
		pauseButton.onClick.AddListener(ProcessClick);
	}
  private void ProcessClick () {
    if (running) {
      PauseGame();
    }
    else {
      ResumeGame();
    }
  }

	public void PauseGame () {
		Time.timeScale = 0;
    running = false;
    buttonText.text = "|>";
	}

  public void ResumeGame () {
		Time.timeScale = 1;
    running = true;
    buttonText.text = "||";
	}

}
