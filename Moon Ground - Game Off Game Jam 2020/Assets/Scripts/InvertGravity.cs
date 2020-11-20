using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    Rigidbody2D rb; // The RigidBody of the Player

    public bool GravityInverted = false; // This will check whether the gravity is inverted or not

    public static bool AbilityIsReady; // Boolean to check whether the Gravity Inversion Ability is ready for use

    private bool PlayerIsFlipped;

    public float abilityCooldown; // The amount of Cooldown

    public ParticleSystem InversionEffect;
    public ParticleSystem NormalizeEffect;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AbilityIsReady = true;
        PlayerIsFlipped = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (AbilityIsReady && !PlayerIsFlipped)
        {
            CheckGravityInversionInput();
        }

        else if (AbilityIsReady && PlayerIsFlipped)
        {
            CheckGravityNormalizeInput();
        }        
               
    }

    public void CheckGravityInversionInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) // Starts Gravity Inversion
        {
            FlipGravity();
        }

        
    }

    public void CheckGravityNormalizeInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) // Stops Gravity Inversion
        {
            NormalizeGravity();
            StartCoroutine("Cooldown");
        }
    }

    public void NormalizeGravity()
    {
        PlayNormalizeEffect();
        GravityInverted = false;
        AbilityIsReady = false;
        PlayerIsFlipped = false;
        FindObjectOfType<AudioManager>().PlaySound("NormalizeGravity");
        rb.gravityScale = 1;
        transform.Rotate(0f, 180f, 180f);
    }

    public void FlipGravity()
    {
        PlayInversionEffect();
        GravityInverted = true;
        PlayerIsFlipped = true;
        FindObjectOfType<AudioManager>().PlaySound("InvertGravity");
        rb.gravityScale = -1;
        transform.Rotate(0f, 180f, 180f);
    }

    public void PlayInversionEffect()
    {
        ParticleSystem inversion = Instantiate(InversionEffect, transform.position, Quaternion.identity);
        inversion.Play();
    }

    public void PlayNormalizeEffect()
    {
        ParticleSystem normalize = Instantiate(NormalizeEffect, transform.position, Quaternion.identity);
        normalize.Play();
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
