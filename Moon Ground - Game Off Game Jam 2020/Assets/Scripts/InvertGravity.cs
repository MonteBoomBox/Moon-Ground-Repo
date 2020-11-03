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
            rb.gravityScale = -1;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GravityInverted = false;
            rb.gravityScale = 1;
        }

    }
}
