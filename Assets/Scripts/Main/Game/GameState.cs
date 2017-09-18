using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Unorthoducks
{
  public class GameState : MonoBehaviour
  {
    public void Start()
    {
      Debug.Log(GameManager.IsGameOver());
    }

    public void FixedUpdate()
    {
      Debug.Log(GameManager.DeadDucks());
      if(GameManager.IsGameOver()) {
        Time.timeScale = 0;
        Debug.Log("you lose");
        // SceneManager.LoadScene("GameOver");
      } else if(GameManager.LevelUp()) {
        Debug.Log("Level finished");
      }
    }
  }
}
