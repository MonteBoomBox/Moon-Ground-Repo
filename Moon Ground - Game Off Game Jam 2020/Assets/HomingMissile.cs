using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public Transform target;
    private Rigidbody2D rb;

    public float rotateSpeed = 200f;
    public float speed = 5f;

    public int playerDamage = 20;
    public float duration = 7f;

    public int maxHealth = 50;
    private int currentHealth;

    public int bulletDamage = 10;

    public GameObject ExplosionEffect;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        StartCoroutine(AutoDestroyMissile());
    }

    // Update is called once per frame
    void FixedUpdate()
    {       

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = target.GetComponent<Health>();
            playerHealth.TakeDamage(playerDamage);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Bullet"))
        {
            DamageMissile(bulletDamage);
        }
    }

    IEnumerator AutoDestroyMissile()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    public void DamageMissile(int damage)
    {
        currentHealth -= damage;
    }
}
