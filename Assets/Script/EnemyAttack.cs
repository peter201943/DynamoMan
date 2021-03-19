using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack the player when in range and not on cooldown
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class EnemyAttack : MonoBehaviour
{
    [Header("Difficulty")]

    [Tooltip("Cooldown between each attack")]
    [SerializeField]
    private float   cooldownMax;

    [Tooltip("Current cooldown of player -- DO NOT SET")]
    [SerializeField]
    private float   cooldownCurrent;

    [Tooltip("How much cooldown do enemies start with?")]
    [SerializeField]
    private float cooldownStart;

    [Tooltip("How much damage to attack the player with")]
    [SerializeField]
    public  int     attackDamage;

    [Header("Sounds")]

    [Tooltip("Emit sounds for attacks")]
    [SerializeField]
    private AudioSource attackSounds;

    [Tooltip("Emitted on attack")]
    [SerializeField]
    private AudioClip attackSound;

    private void Start()
    {
        cooldownCurrent = cooldownStart;
    }

    private void Update()
    {
        cooldownCurrent -= Time.deltaTime;
    }

    /// <summary>
    /// Attacks the PlayerAttack's power reserves
    /// WARN TEMP DEBUG
    /// Meant as a temporary measure only
    /// </summary>
    /// <param name="victim">Who we attack</param>
    private void AttackPlayerAttackTemp(GameObject victim)
    {
        // Check if attacking object is player and we can attack
        if (cooldownCurrent < 0.0 && victim.tag == "Player")
        {
            // Get the Player
            PlayerAttack playerAttack = victim.GetComponent<PlayerAttack>();

            // Effects
            // TODO

            // Attack with our charge type
            // TODO

            // Cooldown
            // TODO
        }
    }

    /// <summary>
    /// Eventual way of attacking any object generically
    /// </summary>
    private void AttackPower()
    {
        // TODO
    }
}
