using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack the player when in range and not on cooldown
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class EnemyAttack : MonoBehaviour
{
    [Tooltip("Cooldown between each attack")]
    [SerializeField]
    private float   cooldownMax;

    [Tooltip("Current cooldown of player -- DO NOT SET")]
    [SerializeField]
    private float   cooldownCurrent;
    
    [Tooltip("How much damage to attack the player with")]
    [SerializeField]
    public  int     attackDamage;
}
