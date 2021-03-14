using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Power:
/// * A class, similar to Health in other videogames
/// * Damage
/// * Heal
/// * Current
/// * Max
/// </summary>
[RequireComponent(typeof(Brain))]
public class Power : MonoBehaviour
{
    [Header("Power Level Settings")]
    
    [Tooltip("Max Power an entity can ever have")]
    [SerializeField]
    private int max     = 100;
    
    [Tooltip("Power an entity has at game start")]
    [SerializeField]
    private int start   = 50;

    [Tooltip("Current Power of an entity throughout a game")]
    [SerializeField]
    private int current = 50;

    [Tooltip("Power needs some brain to tell to die")]
    [SerializeField]
    private Brain brain;

    /// <summary>
    /// Get the current power level
    /// </summary>
    public int Current()
    {
        return current;
    }

    /// <summary>
    /// Take power away from this entity
    /// OR
    /// Give this entity power
    /// </summary>
    /// <param name="amount">amount of energy to take away</param>
    /// <returns>Energy taken from entity</returns>
    public int Change(int amount)
    {
        // Play Sound Effect
        // TODO

        // Deduct Power
        int remaining = current + amount;
        if (remaining <= 0)
        {
            remaining = 0;
            brain.Die();
        }

        // Return Remaining
        return remaining;
    }
}
