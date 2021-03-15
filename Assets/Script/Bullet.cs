using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Damage done by a single bullet")]
    [SerializeField]
    private int damage = 20;

    /// <summary>
    /// Ensure we do not leave any spare bullets around by accident
    /// </summary>
    private void Start()
    {
        Destroy(obj: gameObject, t: 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collides with a like-charged object
        if (collision.gameObject.tag == this.gameObject.tag)
        {   
            // Notify the target (if it is of our charge)
            try
            {
                collision.gameObject.GetComponent<Power>().Current -= damage;
            }
            catch
            {
            }

            // Destroy Ourselves
            Destroy(this.gameObject);
        }

        // Colides with a Wall
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != this.gameObject.tag)
        {
            Destroy(this.gameObject);
        }
    }
}
