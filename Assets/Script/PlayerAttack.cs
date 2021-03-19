using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Handles almost everything for the player
/// Really needs to be split up into multiple separate classes
/// </summary>
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Power))]
public class PlayerAttack : MonoBehaviour
{
    [Header("Gun Logic")]
    public  Transform       firepoint;
    public  GameObject[]    bulletPrefeb;
    public  GameObject[]    BulletUIImage;
    
    [Header("Bullet Logic")]
    public  int             BulletType      = 1;
    public  int[]           RemainBullet;
    public  Text[]          BulletText;
    public  float           bulletforce     = 20f;
    
    [Header("Sounds")]
    public  AudioSource     playerSound;
    public  AudioClip       positiveSwap;
    public  AudioClip       negativeSwap;
    public  AudioClip       gunFire;
    public  AudioClip       pickup;

    // Layer/Charge Logic
    private int             supplyLayer;
    private int             negativeLayer;
    private int             positiveLayer;
    private Power           power;

    void Start()
    {
        // Get Layers
        supplyLayer = LayerMask.NameToLayer("Supply");
        negativeLayer = LayerMask.NameToLayer("Negative");
        positiveLayer = LayerMask.NameToLayer("Positive");

        // Set Starting Bullets
        BulletText[1].text = RemainBullet[1].ToString();
        BulletText[0].text = RemainBullet[0].ToString();

        // Set Starting Charge
        power = GetComponent<Power>();
        power.charge = Charge.Positive;
    }

    void Update()
    {
        CheckNumberKeySwap();
        CheckSpacebarSwap();
        CheckMouseClickFire();
    }

    private void CheckNumberKeySwap()
    {
        // Swap to Negative
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Bullet
            BulletType = 0;

            // Logic
            power.charge = Charge.Negative;
            gameObject.layer = negativeLayer;

            // Effects
            playerSound.clip = negativeSwap;
            playerSound.Play();
        }

        // Swap to Positive
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Bullet
            BulletType = 1;

            // Logic
            power.charge = Charge.Positive;
            gameObject.layer = positiveLayer;

            // Effects
            playerSound.clip = positiveSwap;
            playerSound.Play();
        }
    }


    private void CheckSpacebarSwap()
    {
        // Spacebar Swapping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Swap to Negative
            if (power.charge == Charge.Positive)
            {
                // Bullet
                BulletType = 0;

                // Logic
                power.charge = Charge.Negative;
                gameObject.layer = negativeLayer;

                // Effects
                playerSound.clip = negativeSwap;
                playerSound.Play();

                // Stop Evaluating
                return;
            }

            // Swap to Positive
            if (power.charge == Charge.Negative)
            {
                // Bullet
                BulletType = 1;

                // Logic
                power.charge = Charge.Positive;
                gameObject.layer = positiveLayer;

                // Effects
                playerSound.clip = positiveSwap;
                playerSound.Play();

                // Stop Evaluating
                return;
            }
        }
    }

    private void CheckMouseClickFire()
    {
        // Mouse Click Firing
        if (Input.GetKeyDown(KeyCode.Mouse0) && RemainBullet[BulletType] > 1)
        {
            RemainBullet[BulletType] -= 1;
            BulletText[BulletType].text = RemainBullet[BulletType].ToString();
            GameObject bullet = Instantiate(bulletPrefeb[BulletType], firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
            playerSound.clip = gunFire;
            playerSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Positive" && collision.gameObject.layer == supplyLayer)
        {
            RemainBullet[1] = 10;
            BulletText[1].text = RemainBullet[1].ToString();
            Destroy(collision.gameObject);
            playerSound.clip = pickup;
            playerSound.Play();
            return;
        }

        if (collision.gameObject.tag == "Negative" && collision.gameObject.layer == supplyLayer)
        {
            RemainBullet[0] = 10;
            BulletText[0].text = RemainBullet[0].ToString();
            Destroy(collision.gameObject);
            playerSound.clip = pickup;
            playerSound.Play();
            return;
        }
    }
}
