using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Unorthoducks
{
  public class GameState : MonoBehaviour
  {

    public void Start()
    {
    }

    public void FixedUpdate()
    {
      if(GameManager.IsGameOver()) {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
      } else if(GameManager.LevelUp()) {
        // Debug.Log("Level finished");
      }
    }

  }
}
