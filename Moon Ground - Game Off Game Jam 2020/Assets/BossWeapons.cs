using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapons : MonoBehaviour
{
    public GameObject homingMissilePrefab;

    public Transform spawnPoint;

    public bool weaponIsCharged;

    private float nextTimeToFire = 0f;
    public float bulletSpeed = 25f;

    public GameObject bulletPrefab;
    public Transform shotPoint;

    Transform player;
    Vector2 moveDirection;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LaunchHomingMissiles()
    {
        Instantiate(homingMissilePrefab, spawnPoint.position, Quaternion.identity);
    }

    public void ShootMachineGun()
    {
        if (weaponIsCharged && Time.time >= nextTimeToFire)
        {
            Shoot();
        }
    }

    IEnumerator ChargeMachineGun()
    {
        yield return new WaitForSeconds(1f);
        weaponIsCharged = true;
    }

    public void Shoot()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        moveDirection = (player.position - bulletClone.transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
}
