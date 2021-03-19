using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack the player when in range and not on cooldown
/// </summary>
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Power))]
public class EnemyAttack : MonoBehaviour
{
    [Header("Difficulty")]

    [Tooltip("Cooldown between each attack")]
    [SerializeField]
    private float       cooldownMax;

    [Tooltip("Current cooldown of player -- DO NOT SET")]
    [SerializeField]
    private float       cooldownCurrent;

    [Tooltip("How much cooldown do enemies start with?")]
    [SerializeField]
    private float       cooldownStart;

    [Tooltip("How much damage to attack the player with")]
    [SerializeField]
    public  int         attackDamage;

    [Header("Sounds")]

    [Tooltip("Emit sounds for attacks")]
    [SerializeField]
    private AudioSource attackSounds;

    [Tooltip("Emitted on attack")]
    [SerializeField]
    private AudioClip   attackSound;

    // Logic
    
    // Use for attack type
    private Power power;

    private void Start()
    {
        cooldownCurrent = cooldownStart;
        power = GetComponent<Power>();
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
            attackSounds.clip = attackSound;
            attackSounds.Play();

            // Attack with our charge type
            if (power.charge == Charge.Positive)
            {
                playerAttack.RemainBullet[1] -= attackDamage;
                playerAttack.BulletText[1].text = playerAttack.RemainBullet[1].ToString();
            }
            else if (power.charge == Charge.Negative)
            {
                playerAttack.RemainBullet[0] -= attackDamage;
                playerAttack.BulletText[0].text = playerAttack.RemainBullet[0].ToString();
            }

            // Cooldown
            cooldownCurrent = cooldownMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackPlayerAttackTemp(collision.gameObject);
    }

    /// <summary>
    /// Eventual way of attacking any object generically
    /// </summary>
    private void AttackPower()
    {
        // TODO
    }
}
