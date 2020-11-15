using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GasBubbleAI : MonoBehaviour
{
    Transform target;

    public float speed;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;

        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
