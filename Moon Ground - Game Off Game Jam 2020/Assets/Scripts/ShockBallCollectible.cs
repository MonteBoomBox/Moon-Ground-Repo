using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBallCollectible : MonoBehaviour
{
    public GameObject electricityEffect;

    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.CompareTag("Player"))
        {
            Instantiate(electricityEffect, transform.position, transform.rotation);
            GameObject PlayerBlaster = GameObject.FindGameObjectWithTag("Blaster");
            Blaster shockBallAmmo = PlayerBlaster.GetComponentInChildren<Blaster>();
            shockBallAmmo.currentShockBallAmmo += 1;
            Destroy(gameObject);
        }
    }
}
