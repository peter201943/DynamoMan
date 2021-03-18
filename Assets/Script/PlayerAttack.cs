using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public  Transform       firepoint;
    public  GameObject[]    bulletPrefeb;
    public  GameObject[]    BulletUIImage;
    public  int             BulletType      = 1;
    public  int[]           RemainBullet;
    public  Text[]          BulletText;
    public  float           bulletforce     = 20f;
    private int             supplyLayer;

    void Start()
    {
        supplyLayer = LayerMask.NameToLayer("Supply");
        BulletText[1].text = RemainBullet[1].ToString();
        BulletText[0].text = RemainBullet[0].ToString();
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
            BulletType = 1-BulletType;
        }
       

        if (Input.GetKeyDown(KeyCode.Mouse0) && RemainBullet[BulletType] > 1)
        {
            RemainBullet[BulletType] = RemainBullet[BulletType] - 1;
            BulletText[BulletType].text = RemainBullet[BulletType].ToString();
            Attack();
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
            return;
        }

        if (collision.gameObject.tag == "Negative" && collision.gameObject.layer == supplyLayer)
        {
            RemainBullet[0] = 10;
            BulletText[0].text = RemainBullet[0].ToString();
            Destroy(collision.gameObject);
            return;
        }
    }
}
