using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    Rigidbody2D rb; // The RigidBody of the Player

    public bool GravityInverted = false; // This will check whether the gravity is inverted or not

    private bool AbilityIsReady; // Boolean to check whether the Gravity Inversion Ability is ready for use

    public float abilityCooldown; // The amount of Cooldown

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AbilityIsReady = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Starts Gravity Inversion
        {                
            if (AbilityIsReady)
            {
                FlipGravity();
            }
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift)) // Stops Gravity Inversion
        {
            if (!AbilityIsReady)
            {
                return; // Do Nothing
            }

            else if (AbilityIsReady)
            {
                NormalizeGravity();
                AbilityIsReady = false;
                StartCoroutine("Cooldown");
            }                                    
        }
    }

    public void NormalizeGravity()
    {
        GravityInverted = false;
        FindObjectOfType<AudioManager>().PlaySound("NormalizeGravity");
        rb.gravityScale = 1;
        transform.Rotate(0f, 180f, 180f);
    }

    public void FlipGravity()
    {
        GravityInverted = true;
        FindObjectOfType<AudioManager>().PlaySound("InvertGravity");
        rb.gravityScale = -1;
        transform.Rotate(0f, 180f, 180f);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(abilityCooldown);
        AbilityIsReady = true;
    }

    //IEnumerator CooldownTimer()
    //{
    //    while (true)
    //    {            
    //        yield return new WaitForSeconds(waitingTime);
    //        cooldownTimer += 1;
    //        Debug.Log(cooldownTimer);
    //    }

    //}

    //nextUse = Time.time + inversionRate;
    //cooldownStarted = true;



    //if (cooldownStarted)
    //{
    //    StartCoroutine(abilityCooldownTimer);

    //    if (cooldownTimer >= cooldownTime)
    //    {
    //        NormalizeGravity();
    //        Debug.Log("Stop Ability! Start Cooldown");
    //        StopCoroutine(abilityCooldownTimer);
    //        cooldownStarted = false;
    //    }
    //}

    //else if (!cooldownStarted)
    //{
    //    StopCoroutine(abilityCooldownTimer);
    //    cooldownStarted = false;
    //}
}
