using UnityEngine;

public class PowerUpShield : PowerUpBase
{
    public override void Apply(PlayerController player)
    {
        player.ActivateShield();
    }
}
