using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Unorthoducks
{
  public class GameState : MonoBehaviour
  {
    public ZombieSpawner zombieSpawner;
    public DuckSpawner duckSpawner;

    public void Start()
    {
      Restart();
    }

    public void Restart()
    {
      GameManager.BeginRound();
      zombieSpawner.Init();
      duckSpawner.Init();
    }

    public void Update()
    {
      if(GameManager.IsGameOver()) {
        SceneManager.LoadScene("GameOver");
        Invoke("Restart", 2f);
      } else if(GameManager.LevelComplete()) {
        GameManager.EndRound();
        zombieSpawner.Init();
      }
    }
  }
}
