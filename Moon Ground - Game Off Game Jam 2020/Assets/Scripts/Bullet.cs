using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        else if (HitInfo.gameObject.CompareTag("Reflector"))
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
            FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
