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

    [Tooltip("How long to despawn")]
    [SerializeField]
    private float deathTime;

    [Tooltip("Where sounds play from")]
    [SerializeField]
    private AudioSource enemySound;

    [Tooltip("Played on Spawn")]
    [SerializeField]
    private AudioClip   spawnSound;

    [Tooltip("Played on Death")]
    [SerializeField]
    private AudioClip   deathSound;

    public void Spawn()
    {
        // Re-Actvate the Components
        ec.enabled = true;
        ea.enabled = true;

        // Play any effects
        enemySound.clip = spawnSound;
        enemySound.Play();

        // Notify any systems
        // TODO
    }

    public void Die()
    {
        // Disable the Components
        ec.enabled = false;
        ea.enabled = false;

        // Play any effects
        enemySound.clip = deathSound;
        enemySound.Play();

        // Notify any systems
        // TODO

        // Start Death
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        // Wait
        yield return new WaitForSecondsRealtime(deathTime);

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
