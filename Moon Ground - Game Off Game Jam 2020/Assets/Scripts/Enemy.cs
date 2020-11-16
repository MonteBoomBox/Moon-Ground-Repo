using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBullet;

    public float fireRate;
    private float nextFire;

    public float moveSpeed = 5f;

    GameObject target;
    Vector2 moveDirection;
    Rigidbody2D rb;


    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    public void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Shoot();            
            nextFire = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("BlasterShoot");
        GameObject newEnemyBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = newEnemyBullet.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - newEnemyBullet.transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
}
