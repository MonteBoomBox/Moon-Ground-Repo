using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    GameObject target;
    Vector2 moveDirection;
    GameObject newEnemyBullet;

    public float offset = 0f;

    public Transform shotPoint;

    public float moveSpeed = 20f;

    public float timeToChangeCollider;

    Vector3 difference;

    public void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        RotateBlaster();
    }

    public void Shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("BlasterShoot");
        newEnemyBullet = Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = newEnemyBullet.GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - newEnemyBullet.transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    public void RotateBlaster()
    {
        difference = target.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
