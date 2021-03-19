using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PolarDoor:
/// * This will only deactivate collisions with certain objects
/// * Whilst still enabling collisions with other objects
/// * It may be helpful to think of it less like a door
/// * And more like a screen or filter
/// 
/// Future:
/// * Consider only playing a sound or changing the appearance if the PLAYER
///   can pass through.
/// * Consider making the door enable/disable collisions for ALL OBJECTS if any
///   valid objects are trying to pass through
/// * Consider using an Animator to control playing effects like
///   * Lights
///   * Sounds
///   * Colliders
///   * Etc.
/// 
/// <see href="https://docs.unity3d.com/ScriptReference/Animation.Play.html">Animation.Play</see>
/// <see href="https://answers.unity.com/questions/686915/how-do-i-get-some-objects-to-ignore-collision-with.html">How do i get some objects to ignore collision with a specific object?</see>
/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments">Named Arguments</see>
/// <see href="https://answers.unity.com/questions/1383663/how-to-enable-the-collision-between-two-objects-af.html">How to enable the collision between two objects after using Physics2D.IgnoreCollision() ?</see>
/// <see href="https://docs.unity3d.com/ScriptReference/Physics2D.GetIgnoreCollision.html">Physics2D.GetIgnoreCollision</see>
/// </summary>
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class PolarDoor : MonoBehaviour
{
    public  AudioSource doorSound;
    public  AudioClip   doorOn;
    public  AudioClip   doorOff;
    public  AudioClip   doorFail;
    private Collider2D  collider;

    private void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        if (gameObject.layer != LayerMask.NameToLayer("Negative") || gameObject.layer != LayerMask.NameToLayer("Positive"))
        {
            Debug.LogError("Error: Door Collision Layer Not Valid\nExpected " + LayerMask.NameToLayer("Positive") + " or " + LayerMask.NameToLayer("Negative") + " but got " + gameObject.layer);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="collision">Any object trying to pass through a doorway</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Charged Interaction
        if ( collision.gameObject.layer == gameObject.layer )
        {
            // Play Power Down Sound
            doorSound.clip = doorOff;
            doorSound.Play();

            // Disable Collisions with that Object
            Physics2D.IgnoreCollision(
                collider1:  collider,
                collider2:  collision,
                ignore:     true
            );

            // Do Not Evaluate Any Other Conditions
            return;
        }

        // Any Other Interaction
        {
            // Play Power Failure Sound
            doorSound.clip = doorFail;
            doorSound.Play();

            // Do Not Evaluate Any Other Conditions
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Ignoring Collisions
        if ( Physics2D.GetIgnoreCollision(collider1: collider, collider2: collision ) )
        {
            // Play Power Up Sound
            doorSound.clip = doorOn;
            doorSound.Play();

            // Reactivate Collisions
            Physics2D.IgnoreCollision(
                collider1:  collider,
                collider2:  collision,
                ignore:     false
            );

            // Do Not Evaluate Any Other Conditions
            return;
        }

        // Any Other Interaction
        {
            // Play No Sound

            // Do Not Evaluate Any Other Conditions
            return;
        }
    }
}
