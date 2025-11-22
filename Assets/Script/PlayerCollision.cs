using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gm;
    public PlayerController playerController;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (playerController.shieldActive)
            {
                playerController.shieldActive = false;
                // TODO: Hilangkan efek shield
            }
            else
            {
                gm.GameOver();
            }
        }
    }

}
