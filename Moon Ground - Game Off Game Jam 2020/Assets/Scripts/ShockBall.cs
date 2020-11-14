using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBall : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.CompareTag("Player"))
        {
            GameObject PlayerBlaster = GameObject.FindGameObjectWithTag("Blaster");
            Blaster shockBallAmmo = PlayerBlaster.GetComponentInChildren<Blaster>();
            shockBallAmmo.currentShockBallAmmo += 1;
            Destroy(gameObject);
        }
    }
}
