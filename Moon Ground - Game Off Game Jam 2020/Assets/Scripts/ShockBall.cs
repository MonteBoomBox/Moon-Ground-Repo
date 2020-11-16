using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBall : MonoBehaviour
{
    public int playerDamage = 20;
    public int enemyDamage = 100;

    private int BounceCounter;
    public int BounceLimit;

    public void Update()
    {
        if (BounceCounter == BounceLimit)
        {
            Destroy(gameObject);
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        GameObject Obj = HitInfo.gameObject;

        if (HitInfo.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = Obj.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Reflector"))
        {
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }    

    public void OnCollisionEnter2D(Collision2D collider) // When Collider is not Trigger
    {
        GameObject Obj = collider.gameObject;

        if (collider.gameObject.CompareTag("Player"))
        {
            GameObject PlayerBlaster = GameObject.FindGameObjectWithTag("Blaster");
            Blaster shockBallAmmo = PlayerBlaster.GetComponentInChildren<Blaster>();
            shockBallAmmo.currentShockBallAmmo += 1;
            Destroy(gameObject);
        }

        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = Obj.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }

        else if (collider.gameObject.CompareTag("Ground"))
        {
            BounceCounter += 1;
        }

        else if (collider.gameObject.CompareTag("Reflector"))
        {
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
            BounceCounter += 1;
        }
    }    
}
