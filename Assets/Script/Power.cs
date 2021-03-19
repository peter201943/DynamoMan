using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows objects to be negative or positive
/// </summary>
public enum Charge
{
    Positive,
    Negative
}

/// <summary>
/// Power:
/// * A class, similar to Health in other videogames
/// * Damage
/// * Heal
/// * Current
/// * Max
/// <see href="https://www.reddit.com/r/Unity3D/comments/59na4t/psa_you_can_use/">PSA: You can use [RequireComponent(typeof(IMyInterface))] as long as your interface is in a script which is NOT named the same as the interface</see>
/// <see href="https://www.gamasutra.com/blogs/VictorBarcelo/20131217/207204/Using_abstractions_and_interfaces_with_Unity3D.php">Using abstractions and interfaces with Unity3Dhttps://www.gamasutra.com/blogs/VictorBarcelo/20131217/207204/Using_abstractions_and_interfaces_with_Unity3D.php</see>
/// <see href="http://hightalestudios.com/2017/03/friends-dont-let-friends-use-interfaces-on-monobehaviour-objects/">Friends Don’t Let Friends Use Interfaces on MonoBehaviour Objects</see>
/// <see href="https://answers.unity.com/questions/46210/how-to-expose-a-field-of-type-interface-in-the-ins.html">How to expose a field of type Interface in the inspector?</see>
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

    [Header("Notification Settings")]

    [Tooltip("Power needs some brain to tell to die")]
    [SerializeField]
    private Brain brain;

    [Header("Charge Settings")]

    [Tooltip("Current Charge")]
    [SerializeField]
    public  Charge charge;

    private void Start()
    {
        // Get the brain via script because the Inspector is too stupid to handle an Interface
        // WARN possible deprecation in FUTURE
        brain = GetComponent<Brain>();

        // Check for common problems because of lack of type safety
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

        // set our current level
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
