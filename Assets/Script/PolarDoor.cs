using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class PolarDoor : MonoBehaviour
{
    public AudioSource  doorSound;
    public AudioClip    doorOn;
    public AudioClip    doorOff;
    public AudioClip    doorFail;

    private int         negative;
    private int         positive;
    private Collider2D  collider;

    private void Start()
    {
        negative = LayerMask.NameToLayer("Negative");
        positive = LayerMask.NameToLayer("Positive");
        collider = gameObject.GetComponent<Collider2D>();
    }

    /// <summary>
    /// <see href="https://answers.unity.com/questions/686915/how-do-i-get-some-objects-to-ignore-collision-with.html">How do i get some objects to ignore collision with a specific object?</see>
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments">Named Arguments</see>
    /// <see href="https://answers.unity.com/questions/1383663/how-to-enable-the-collision-between-two-objects-af.html">How to enable the collision between two objects after using Physics2D.IgnoreCollision() ?</see>
    /// <see href="https://docs.unity3d.com/ScriptReference/Physics2D.GetIgnoreCollision.html">Physics2D.GetIgnoreCollision</see>
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
