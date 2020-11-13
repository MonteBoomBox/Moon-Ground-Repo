using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    InvertGravity something;    

    IEnumerator useTimer;
    IEnumerator cooldownTimer;

    private bool isUseTimerStarted = false;
    private bool isCooldownStarted = false;

    private float useTime;
    public float useLimit;

    private float cooldownTime;
    public float cooldownLimit;


    public void Start()
    {
        useTimer = abilityUseTimer();
        

        something = GetComponent<InvertGravity>();
    }

    
    public void Update()
    {
        if (something.GravityInverted == true)
        {
            if (!isUseTimerStarted)
            {
                Debug.Log("Start Use Timer!");
                useTime = 0;
                StartCoroutine(useTimer);
                isUseTimerStarted = true;
            }

            
        }

        else if (something.GravityInverted == false)
        {
            if (isUseTimerStarted)
            {
                Debug.Log("Stop Use Timer!");
                StopCoroutine(useTimer);
                isUseTimerStarted = false;
            }

            
        }



        if (useTime == useLimit)
        {
            if (isUseTimerStarted)
            {
                Debug.Log("Ability used up! Cooldown Started");
                StopCoroutine(useTimer);
                isUseTimerStarted = true;
                isCooldownStarted = true;
            }

        }

        

        if (isCooldownStarted == true)
        {
            Debug.Log("Cooldown Started!");
            something.GravityInverted = false;
            StartCoroutine(cooldownTimer);
        }

        if (cooldownTime == cooldownLimit)
        {
            Debug.Log("Cooldown Ended!");
            isCooldownStarted = false;
        }
    }

    IEnumerator abilityUseTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            useTime += 1;
            Debug.Log(useTime);
        }
    }

    IEnumerator abilityCooldownTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            cooldownTime += 1;
            Debug.Log(cooldownTime);
        }
    }
}
