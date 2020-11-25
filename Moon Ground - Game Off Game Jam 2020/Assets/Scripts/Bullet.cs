using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int BounceCounter = 0;
    public int BounceLimit = 3;

    public int playerDamage;
    public int enemyDamage;

    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Reflector"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");            
        }

        else if (HitInfo.gameObject.CompareTag("Enemy"))
        {
            GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyHealth enemyHealth = Enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (BounceCounter >= BounceLimit)
        {
            Destroy(gameObject); // When the bounce counter reaches a certain limit, the bullet will get destroyed
        }
    }

    public void OnCollisionEnter2D(Collision2D BulletCollider) // When the bullet touches anything that is tagged as "Ground", it will increment Boucne Counter by 1
    {
        if (BulletCollider.gameObject.CompareTag("Ground"))
        {
            BounceCounter += 1;
        }

        else if (BulletCollider.gameObject.CompareTag("Reflector"))
        {
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
            BounceCounter += 1;
        }

        else if (BulletCollider.gameObject.CompareTag("Player"))
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Health playerHealth = Player.GetComponent<Health>();
            playerHealth.TakeDamage(playerDamage);
            Destroy(gameObject);
        }

        else if (BulletCollider.gameObject.CompareTag("Enemy"))
        {
            GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyHealth enemyHealth = Enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }

    public void OnBecameInvisible() // When the Bullet goes out of the Camera view, it will get destroyed.
    {
        Destroy(gameObject);
    }
}
