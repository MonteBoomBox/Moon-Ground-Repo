using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;
    private int playerDamage = 10;


    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    InvertGravity Gravity;
    public Health PlayerHealth;
    int ShockBallAmmo;

    public Animator playerAnimator;

    Vector2 ScreenBounds;

    public float killDelay = 0.5f;

    // For Player Data
    public int CurrentLevel;
    public int currentShockballAMMO;

    Blaster SHOCKBALLAMMO;

    

    //public GameObject LavaDropPrefab;
    //public float respawnTime;
    //public float dropForce = 5f;

    //Vector2 RandomSpawnPos;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Gravity = GetComponent<InvertGravity>();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //RandomSpawnPos = new Vector2(Random.Range(25, 50), -13.7f);        
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
            playerAnimator.SetBool("isJumping", false);
        }

        if (Gravity.GravityInverted == false)
        {
            //StopCoroutine(LavaDropsWave());

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
            //StartCoroutine(LavaDropsWave());

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

    public void OnCollisionEnter2D(Collision2D HitInfo) // Collision Detection
    {
        if (HitInfo.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Finished!");
            FindObjectOfType<AudioManager>().PlaySound("WinSound");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (HitInfo.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("You Died!");
            FindObjectOfType<AudioManager>().PlaySound("PlayerDeath");
            PlayerHealth.KillPlayer();            
        }

        else if (HitInfo.gameObject.CompareTag("Lava"))
        {
            Debug.Log("You fell in the lava!");
            SceneManager.LoadScene(1);
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
        playerAnimator.SetBool("isJumping", true);
        rb.velocity = Vector2.up * JumpForce;       
    }

    public void JumpInverted()
    {
        playerAnimator.SetBool("isJumping", true);
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

    //public void SavePlayerData()
    //{
    //    CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    //    SaveSystem.SavePlayer(this);
    //    Debug.Log("Player data saved");
    //}

    //public void LoadPlayerData()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    currentShockballAMMO = data.currentShockBallAmmo;
    //}

    

    //IEnumerator LavaDropsWave()
    //{
    //    GameObject Lava = GameObject.FindGameObjectWithTag("Lava");
    //    GameObject newLavaDrop = Instantiate(LavaDropPrefab, RandomSpawnPos, Lava.transform.rotation);
    //    yield return new WaitForSeconds(respawnTime);
    //    SpawnNewLavaDrop(Lava.transform);        
    //    newLavaDrop.GetComponent<Rigidbody2D>().velocity = Vector2.up * dropForce;
    //}

    //public void SpawnNewLavaDrop(Transform spawnPos)
    //{
    //    GameObject newLavaDrop = Instantiate(LavaDropPrefab, RandomSpawnPos, spawnPos.rotation);
    //}
}
