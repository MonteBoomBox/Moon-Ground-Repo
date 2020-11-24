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
            GetComponentInChildren<EnemyShoot>().Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    
    
}
