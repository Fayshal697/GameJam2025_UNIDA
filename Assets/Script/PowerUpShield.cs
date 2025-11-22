using UnityEngine;

public class PowerUpShield : PowerUpBase
{

    private void Reset()
    {
        displayName = "Shield";
        hasDuration = false;
        duration = 0f;
    }
    public override void Apply(PlayerController player)
    {
        player.ActivateShield();
    }
}
