using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    GameObject target;

    public int playerDamage;
    public int enemyDamage;

    private int BounceCounter = 0;
    public int BounceLimit = 3;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (BounceCounter >= BounceLimit)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        GameObject Obj = HitInfo.gameObject;

        if (HitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Reflector"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        }

        else if (HitInfo.gameObject.CompareTag("Player"))
        {
            Health playerHealth = target.GetComponent<Health>();
            playerHealth.TakeDamage(playerDamage);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D BulletCollider) // When the bullet touches anything that is tagged as "Ground", it will increment Boucne Counter by 1
    {
        GameObject EnemyToDamage = BulletCollider.gameObject;
        if (BulletCollider.gameObject.CompareTag("Ground"))
        {
            BounceCounter += 1;            
        }

        else if (BulletCollider.gameObject.CompareTag("Reflector"))
        {
            BounceCounter += 1;
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        }

        else if (BulletCollider.gameObject.CompareTag("Player"))
        {
            Health health = target.GetComponent<Health>();
            health.TakeDamage(playerDamage);
            Destroy(gameObject);
        }

        else if (BulletCollider.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = EnemyToDamage.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
