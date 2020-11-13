using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    private InverseGrav gravity;

    IEnumerator AbilityUseTimer;
    IEnumerator AbilityCooldownTimer;

    private float mainTimer = 0f;
    public float inversionLimit = 15f;
    public float cooldownTimerLimit = 5f;
    private float cooldownTimer = 0f;

    private bool hasStartedCoroutine = false;
    private bool cooldownStarted = false;

    public void Start()
    {
        AbilityUseTimer = abilityUseTimer();
        AbilityCooldownTimer = CooldownTimer();
    }

    public void Update()
    {
        if (InverseGrav.gravityInversed == true)
        {
            if (hasStartedCoroutine == false)
            {
                StartCoroutine(AbilityUseTimer);
                hasStartedCoroutine = true;
            }            
        }

        else if (InverseGrav.gravityInversed == false)
        {
            if (hasStartedCoroutine == true)
            {
                StopCoroutine(AbilityUseTimer);
                hasStartedCoroutine = false;
            }
        }

        if (mainTimer >= inversionLimit)
        {
            StopCoroutine(AbilityUseTimer);
            Debug.Log("Stop Ability! Start Cooldown");

            if (!cooldownStarted)
            {
                StartCoroutine(AbilityCooldownTimer);
            }
        }

        if (cooldownTimer >= cooldownTimerLimit)
        {
            if (cooldownStarted)
            {
                StopCoroutine(AbilityCooldownTimer);
            }            
        }
    }

    IEnumerator abilityUseTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            mainTimer += 1;
            Debug.Log(mainTimer);
        }
    }

    IEnumerator CooldownTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            cooldownTimer += 1;            
        }
    }
}
