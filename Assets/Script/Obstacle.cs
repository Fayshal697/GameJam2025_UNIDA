using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public bool destroyOnPlayerHit = true;   // obstacle hilang setelah kena player
    public bool destroyWhenOffScreen = true; // auto clean ketika keluar kamera

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pastikan hanya bereaksi terhadap Player
        if (!collision.CompareTag("Player")) return;

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player == null) return;

        // Jika player punya power-up shield / attack
        if (player.CanBreakObstacle)
        {
            player.UseObstacleBreaker(); // konsumsi power-up
            Destroy(gameObject);
            return;
        }

        // Jika tidak ada shield / power-up → player kena obstacle
        player.OnHitObstacle();

        if (destroyOnPlayerHit)
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        if (destroyWhenOffScreen)
            Destroy(gameObject);
    }

    
}
