using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    Transform destination;

    public bool isBlue;
    public bool isRed;

    public float distanceToPortal = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        if (isRed == true)
        {
            destination = GameObject.FindGameObjectWithTag("ExitRedPort").GetComponent<Transform>();
        }

        else if (isBlue == true)
        {
            destination = GameObject.FindGameObjectWithTag("ExitBluePort").GetComponent<Transform>();
        }
    }


    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (Vector2.Distance(transform.position, HitInfo.transform.position) > distanceToPortal)
        {
            HitInfo.transform.position = new Vector2(destination.position.x, destination.position.y);
        }


    }
}
