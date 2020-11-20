using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isMoving;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = true;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = false;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.SetParent(null);
        }
    }
}
