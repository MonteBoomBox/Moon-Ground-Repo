using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;


    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    InvertGravity Gravity;

    public Animator playerAnimator;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Gravity = GetComponent<InvertGravity>();
    }

    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        
    }

    public void Update()
    {
        

        if (isGrounded == true)
        {
            extraJumps = 2;
        }

        if (Gravity.GravityInverted == false)
        {
            if (Input.GetButtonDown("Jump") && extraJumps > 0)
            {
                Jump();
                extraJumps--;
            }

            else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
            {
                Jump();
            }
        }

        else if (Gravity.GravityInverted == true)
        {
            if (Input.GetButtonDown("Jump") && extraJumps > 0)
            {
                JumpInverted();
                extraJumps--;
            }

            else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
            {
                JumpInverted();
            }
        }

        
    }

    public void OnCollisionEnter2D(Collision2D HitInfo)
    {
        if (HitInfo.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Finished!");
            FindObjectOfType<AudioManager>().PlaySound("WinSound");
        }

        else if (HitInfo.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("You Died!");
            FindObjectOfType<AudioManager>().PlaySound("PlayerDeath");
            Invoke("LoadSameLevel", 3.5f);
        }
    }

    public void LoadSameLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * JumpForce;       
    }

    public void JumpInverted()
    {
        rb.velocity = Vector2.down * JumpForce;
    }

    public void PlayStepSound1()
    {
        if (isGrounded == true)
        {
            FindObjectOfType<AudioManager>().PlaySound("PlayerStep1");
        }        
    }

    public void PlayStepSound2()
    {
        if (isGrounded == true)
        {
            FindObjectOfType<AudioManager>().PlaySound("PlayerStep2");
        }
    }
}
