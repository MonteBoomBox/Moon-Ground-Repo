using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool InvertedJump = false;

    
    //float LevelLoadDelay = 2f;
    //public GameObject deathEffect;

    InvertGravity Inverted;

    public void Start()
    {
        Inverted.GetComponent<InvertGravity>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Inverted.GravityInverted)
        {
            InvertedJump = true;
        }

        else if (Input.GetButtonDown("Jump") && Inverted.GravityInverted == false)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, InvertedJump);
        jump = false;
        InvertedJump = false;
    }
}
