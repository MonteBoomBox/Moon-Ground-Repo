using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    public int Damage;

    private int BounceCounter = 0;
    public int BounceLimit = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
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
        if (HitInfo.gameObject.CompareTag("Player"))
        {
            Health health = target.GetComponent<Health>();
            health.TakeDamage(Damage);
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Reflector"))
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        }
    }

    public void OnCollisionEnter2D(Collision2D BulletCollider) // When the bullet touches anything that is tagged as "Ground", it will increment Boucne Counter by 1
    {
        if (BulletCollider.gameObject.CompareTag("Ground"))
        {
            BounceCounter += 1;
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
