using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera cam;
    private Rigidbody2D myrb;
    private Vector2 movement;
    private Vector2 mouseposition;
    private int negative;
    private int positive;

    private void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        negative = LayerMask.NameToLayer("Negative");
        positive = LayerMask.NameToLayer("Positive");
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        myrb.MovePosition(myrb.position + movement * speed * Time.deltaTime);
        Vector2 lookDir = mouseposition - myrb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        myrb.rotation = angle;
    }
}
