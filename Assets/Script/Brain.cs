using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic entity script that others extend
/// <see href="https://forum.unity.com/threads/c-interfaces-tutorial.159849/">C# interfaces tutorial</see>
/// </summary>
public interface Brain
{
    /// <summary>
    /// Kill this entity
    /// Stops it from moving
    /// Starts whatever death means for this thing
    /// </summary>
    void Die();

    /// <summary>
    /// Tell this entity to start moving around
    /// </summary>
    void Spawn();

    /// <summary>
    /// Should call spawn with some extra effects
    /// </summary>
    void Respawn();
}
