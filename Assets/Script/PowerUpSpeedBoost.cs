using UnityEngine;

public class PowerUpSpeedBoost : PowerUpBase
{
    public float speedMultiplier = 1.5f;

    public override void Apply(PlayerController player)
    {
        player.StartCoroutine(player.ActivateSpeedBoost(duration, speedMultiplier));
    }
}
