using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Brain for Player
/// * Does NOT handle movement
/// * Does NOT handle attacking
/// </summary>
public class BrainPlayer : Brain
{
    [Tooltip("What the player moves with")]
    [SerializeField]
    private PlayerController pc;

    [Tooltip("What the player shoots with")]
    [SerializeField]
    private PlayerAttack pa;

    public void Spawn()
    {
        // Re-Actvate the Components
        pc.enabled = true;
        pa.enabled = true;

        // Play any effects
        // TODO

        // Notify any systems
        // TODO
    }

    public void Die()
    {
        // Disable the Components
        pc.enabled = false;
        pa.enabled = false;

        // Play any effects
        // TODO

        // Notify any systems
        // TODO
    }

    public void Respawn()
    {
        // Same as spawn
        Spawn();

        // Any special effects
        // (None)
    }
}
