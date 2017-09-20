using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Unorthoducks
{
  public class GameState : MonoBehaviour
  {
    public ZombieSpawner zombieSpawner;
    public void Start()
    {
      GameManager.BeginRound();
      zombieSpawner.Init();
    }

    public void Update()
    {
      if(GameManager.IsGameOver()) {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
      } else if(GameManager.LevelComplete()) {
        GameManager.EndRound();
        zombieSpawner.Init();
      }
    }
  }
}
