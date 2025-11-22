using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public float duration = 3f;   // untuk powerup yang punya waktu
    public bool hasDuration = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Apply(other.GetComponent<PlayerController>());
            Destroy(gameObject); // powerup hilang setelah diambil
        }
    }

    public abstract void Apply(PlayerController player);
}
