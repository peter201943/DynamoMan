using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PICKS UP pickups
/// Is NOT a pickup
/// Put on objects that you want to be able to pickup batteries
/// NOTICE NOT IN USE DO NOT USE
/// </summary>
public class PowerPickup : MonoBehaviour
{
    [Header("Power")]
    
    [Tooltip("Power Source of Picker-Upper")]
    [SerializeField]
    private Power power;

    [Header("Sounds")]

    [Tooltip("Play sounds for picking up objects")]
    [SerializeField]
    private AudioSource     pickupSound;

    [Tooltip("Played on item pickup")]
    [SerializeField]
    private AudioClip       pickup;

    // Layer Logic
    private int             supplyLayer;

    private void Start()
    {
        supplyLayer = LayerMask.NameToLayer("Supply");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Positive" && collision.gameObject.layer == supplyLayer)
        {
            // Logic
            power.Current += 1; // TODO
            Destroy(collision.gameObject);

            // Effects
            pickupSound.clip = pickup;
            pickupSound.Play();
            
            // Stop Evaluating
            return;
        }

        if (collision.gameObject.tag == "Negative" && collision.gameObject.layer == supplyLayer)
        {
            // Logic
            power.Current += 1; // TODO
            Destroy(collision.gameObject);

            // Effects
            pickupSound.clip = pickup;
            pickupSound.Play();

            // Stop Evaluating
            return;
        }
    }
}
