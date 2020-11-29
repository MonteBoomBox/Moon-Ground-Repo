using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public int timeToEnrageAmount = 500;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= timeToEnrageAmount)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
    }

    public void TakeHeadshotDamage(int headshotDamage)
    {
        currentHealth -= headshotDamage;
    }

    public void TakeBodyDamage(int bodyDamage)
    {
        currentHealth -= bodyDamage;
    }
}
