using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {   
            // Notify the target (if it is of our charge)
            try
            {
                // collision.gameObject.GetComponent<Power>().Current -= damage;
            }
            catch
            {
            }

            // Destroy Ourselves
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != this.gameObject.tag)
        {
            Destroy(this.gameObject);
        }
    }
}
