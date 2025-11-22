using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float score;
    public float scoreRate = 5f; // score per second
    public bool isPlaying = false;
    private UIManager uiManager; 


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

        uiManager = FindFirstObjectByType<UIManager>();
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

    void Update()
    {
        if (isPlaying)
        {
            score += scoreRate * Time.deltaTime;
            uiManager.UpdateScore(score);
        }
    }

    public void ShowPowerUpText(string name)
    {
        uiManager?.ShowPowerUp(name);
    }

}
