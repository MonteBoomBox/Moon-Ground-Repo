using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDropDrop : MonoBehaviour
{
    public int playerDamage = 5;
    public int enemyDamage = 10;

    Health PlayerHealth;
    EnemyHealth enemyHealth;

    public void Start(){

        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Reflector"))
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.TakeDamage(playerDamage);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyDamage);
        }
    }
}
