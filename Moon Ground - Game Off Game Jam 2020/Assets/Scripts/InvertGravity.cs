using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    Rigidbody2D rb;

    public bool GravityInverted = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GravityInverted = true;
            FindObjectOfType<AudioManager>().PlaySound("InvertGravity");
            rb.gravityScale = -1;
            transform.Rotate(0f, 180f, 180f);
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GravityInverted = false;
            FindObjectOfType<AudioManager>().PlaySound("NormalizeGravity");
            rb.gravityScale = 1;
            transform.Rotate(0f, 180f, 180f);
        }

    }
}
