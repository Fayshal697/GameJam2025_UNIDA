using UnityEngine;

public class PowerUpSpeedBoost : PowerUpBase
{
    public float speedMultiplier = 1.5f;

    private void Reset()
    {
        displayName = "Speed Boost";
        hasDuration = true;
        duration = 3f;
    }
    public override void Apply(PlayerController player)
    {
        player.StartCoroutine(player.ActivateSpeedBoost(duration, speedMultiplier));
    }
}
