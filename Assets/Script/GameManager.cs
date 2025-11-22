using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        // Singleton sederhana
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        // Freeze game
        Time.timeScale = 0f;

        // Nanti bisa munculkan UI Game Over
        // For now → auto restart dalam 1 detik
        Invoke("RestartGame", 1f);
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Power-Up pick up system
    public void CollectPowerUp(GameObject powerup)
    {
        Debug.Log("PowerUp collected: " + powerup.name);

        // Nanti disambungkan ke PowerUpHandler
        // Ex: player.GetComponent<PowerUpHandler>().AddPowerUp(type);

        Destroy(powerup);
    }
}
