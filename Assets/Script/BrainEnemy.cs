using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Brain for Enemies
/// * Does NOT handle movement
/// * Does NOT handle attacking
/// </summary>
public class BrainEnemy : MonoBehaviour, Brain
{
    [Tooltip("What the enemy moves with")]
    [SerializeField]
    private EnemyController ec;

    [Tooltip("What the enemy attacks with")]
    [SerializeField]
    private EnemyAttack ea;

    public void Spawn()
    {
        // Re-Actvate the Components
        ec.enabled = true;
        ea.enabled = true;

        // Play any effects
        // TODO

        // Notify any systems
        // TODO

        // Delete Self
        // TODO
    }

    public void Die()
    {
        // Disable the Components
        ec.enabled = false;
        ea.enabled = false;

        // Play any effects
        // TODO

        // Notify any systems
        // TODO

        // Delete Self
        Destroy(gameObject);
    }

    public void Respawn()
    {
        // Same as spawn
        Spawn();

        // Any special effects
        // (None)
    }
}
