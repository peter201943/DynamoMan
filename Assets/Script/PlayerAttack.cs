﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
    private Charge          charge;

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
        charge = Charge.Positive;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletUIImage[BulletType].GetComponent<Image>().color = new Color32(255,255,255,100);
            BulletText[BulletType].color = new Color32(255, 255, 255, 100);
            BulletType = 0;
            BulletText[BulletType].color = new Color32(255, 255, 255, 255);
            BulletUIImage[BulletType].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletUIImage[BulletType].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            BulletText[BulletType].color = new Color32(255, 255, 255, 100);
            BulletType = 1;
            BulletText[BulletType].color = new Color32(255, 255, 255, 255);
            BulletUIImage[BulletType].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Swap Bullet
            BulletType = 1-BulletType;
            
            // Swap Charge and Layer and Emit Sound
            if (charge == Charge.Positive)
            {
                charge = Charge.Negative;
                gameObject.layer = negativeLayer;
                playerSound.clip = negativeSwap;
                playerSound.Play();
            }
            else if (charge == Charge.Negative)
            {
                charge = Charge.Positive;
                gameObject.layer = positiveLayer;
                playerSound.clip = positiveSwap;
                playerSound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && RemainBullet[BulletType] > 1)
        {
            RemainBullet[BulletType] = RemainBullet[BulletType] - 1;
            BulletText[BulletType].text = RemainBullet[BulletType].ToString();
            Attack();
            playerSound.clip = gunFire;
            playerSound.Play();
        }


    }

    private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefeb[BulletType], firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);

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
