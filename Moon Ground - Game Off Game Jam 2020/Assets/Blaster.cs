using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float offset;

    public GameObject bulletPrefab;
    public Transform ShotPoint;
    public float bulletSpeed = 10f;

    public void Update()
    {
        RotateBlaster();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void RotateBlaster()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    public void Shoot()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, ShotPoint.position, ShotPoint.rotation);
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.velocity = ShotPoint.right * bulletSpeed;
    }

}
