using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Unorthoducks
{
  public class ReplayButton : MonoBehaviour {

  	public Button replayButton;

  	void Start () {
  		replayButton.onClick.AddListener(Restart);
  	}

  	void Restart () {
  		GameManager.Restart();
      SceneManager.LoadScene("main");
  	}
  }
}
