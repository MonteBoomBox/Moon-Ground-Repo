﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float regenTime;

    public int maxHealth;
    public int currentHealth;

    public int damageUnit;

    private bool isHit = false;
    [HideInInspector]
    public bool isDead = false;

    public SpriteRenderer ObjRenderer;
    Color defaultColor;

    public ParticleSystem Hit;
    public GameObject explosionEffect;

    public int enemyDead;

    public GameObject GateManager;


    void Start()
    {
        currentHealth = maxHealth;
        defaultColor = ObjRenderer.color;
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Bullet"))
        {
            if (!isHit)
            {                
                isHit = true;
                StartCoroutine("SwitchColor");
                TakeDamage(damageUnit);
            }            
        }
    }

    public void PlayHitEffect()
    {
        FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        ParticleSystem hit = Instantiate(Hit, transform.position, Quaternion.identity);
        hit.Play();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                Die();
            }            
        }
    }

    public void TakeDamage(int damage)
    {
        PlayHitEffect();
        currentHealth -= damage;
    }

    public void Die()
    {
        Debug.Log("Enemy Killed");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().PlaySound("EnemyDeath");
        if (GameObject.Find("Gates Management"))
        {
            GateManager.GetComponent<GateManagement>().GatePassed += 1;
            Debug.Log(GateManager.GetComponent<GateManagement>().GatePassed);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }

    IEnumerator SwitchColor()
    {
        ObjRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(regenTime);
        ObjRenderer.color = defaultColor;
        isHit = false;
    }
}
