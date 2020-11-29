using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public int timeToEnrageAmount = 500;

    public GameObject ExplosionEffect;
    public Transform explosionPoint1;
    public Transform explosionPoint2;

    public GameObject EndScreen;

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

        if (currentHealth <= 0)
        {
            Die();
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

    public void Die()
    {
        ShowExplosions();       
        GetComponent<Animator>().SetBool("isDead", true);
    }

    public void ShowExplosions()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Instantiate(ExplosionEffect, explosionPoint1.position, explosionPoint1.rotation);
        Instantiate(ExplosionEffect, explosionPoint2.position, explosionPoint2.rotation);
    }

    public void PlayIntroSong()
    {
        FindObjectOfType<AudioManager>().PlaySound("EnemyBossIntro");
    }

    public void EndGame()
    {
        EndScreen.SetActive(true);
    }

}
