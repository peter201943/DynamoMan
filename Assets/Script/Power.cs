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

    private void Start()
    {
        if (start > max)
        {
            Debug.LogError("Cannot start with greater than max health");
        }
        if (max < 1)
        {
            Debug.LogError("Max must be greater than zero");
        }
        if (start < 1)
        {
            Debug.LogError("Cannot start with zero health");
        }
        current = start;
    }

    /// <summary>
    /// Get the current power level
    /// </summary>
    public int Current
    {
        get { return current; }
        set
        {
            current += value;
            if (current <= 0)
            {
                brain.Die();
                current = 0;
            }
            if (current > max)
            {
                current = max;
            }
        }
    }
}
