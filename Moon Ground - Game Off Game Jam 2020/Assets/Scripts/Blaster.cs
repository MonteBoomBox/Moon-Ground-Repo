using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blaster : MonoBehaviour
{
    public float offset;

    int BulletToShoot;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public GameObject shockBallPrefab;
    public float shockBallSpeed;

    public Transform ShotPoint;
    

    public int maxBulletAmmo = 15;
    public int maxShockBallAmmo = 10;

    [HideInInspector]
    public int currentBulletAmmo;


    public int currentShockBallAmmo;

    public float reloadTime = 2f;
    private bool isReloading = false;

    public GameObject BulletAmmoDisplay;
    TextMeshProUGUI CurrentBulletAmmoCount;

    public GameObject ShockBallAmmoDisplay;
    TextMeshProUGUI CurrentShockBallAmmoCount;

    GameObject AmmoDisplay;

    private bool isAmmoBullet;


    public void Start()
    {
        isAmmoBullet = true;
        currentBulletAmmo = maxBulletAmmo;
        CurrentBulletAmmoCount = BulletAmmoDisplay.GetComponent<TextMeshProUGUI>();
        CurrentShockBallAmmoCount = ShockBallAmmoDisplay.GetComponent<TextMeshProUGUI>();
        currentShockBallAmmo = 0;
    }

    public void Update()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            CheckAmmoChange();
            DisplayCurrentBulletAmmo();
            DisplayCurrentShockBallAmmo();

            if (isReloading)
            {
                return;
            }

            if (currentBulletAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (currentShockBallAmmo <= 0)
            {
                Debug.Log("You ran out of Ammo!");
                SwitchAmmoToBullet();
            }

            RotateBlaster();

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }        
    }

    public void DisplayCurrentBulletAmmo()
    {
        CurrentBulletAmmoCount.text = currentBulletAmmo.ToString();
    }

    public void DisplayCurrentShockBallAmmo()
    {
        CurrentShockBallAmmoCount.text = currentShockBallAmmo.ToString();
    }

    public void CheckAmmoChange()
    {
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SwitchAmmoToShockBall();
        }

        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SwitchAmmoToBullet();
        }
    }

    public void SwitchAmmoToShockBall()
    {
        BulletToShoot = 2;
    }

    public void SwitchAmmoToBullet()
    {
        BulletToShoot = 1;
    }

    IEnumerator Reload()
    {
        FindObjectOfType<AudioManager>().PlaySound("BlasterReload");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentBulletAmmo = maxBulletAmmo;
        isReloading = false;    
    }

    public void RotateBlaster()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    public void Shoot()
    {
        if (BulletToShoot == 1)
        {
            FindObjectOfType<AudioManager>().PlaySound("BlasterShoot");
            currentBulletAmmo--;
            GameObject bulletClone = Instantiate(bulletPrefab, ShotPoint.position, ShotPoint.rotation);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.velocity = ShotPoint.right * bulletSpeed;
        }

        if (BulletToShoot == 2 && currentShockBallAmmo > 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("BlasterShoot");
            currentShockBallAmmo--;
            GameObject bulletClone = Instantiate(shockBallPrefab, ShotPoint.position, ShotPoint.rotation);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.velocity = ShotPoint.right * bulletSpeed;
        }
    }

}
