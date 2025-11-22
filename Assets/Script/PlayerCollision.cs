using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hit obstacle → langsung Game Over
        if (collision.CompareTag("Obstacle"))
        {
            gm.GameOver();
        }

        // Ambil Power-Up
        if (collision.CompareTag("PowerUp"))
        {
            gm.CollectPowerUp(collision.gameObject);
        }
    }
}
