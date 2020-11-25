using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPump : MonoBehaviour
{
    public GameObject GasBubblePrefab;
    GameObject newGasBubble;

    public Transform spawnPoint;
    public Transform target;

    public float moveSpeed;

    public GasCount gasCount;

    //[SerializeField]
    //private Transform[] waypoints;
    //private int waypointIndex = 0;
    private bool movementStarted = false;

    //private float timeLeft;
    //public float accelerationTime = 5f;

    //Rigidbody2D rb;
    //Vector2

    public void SpawnGasBubble()
    {
        newGasBubble = Instantiate(GasBubblePrefab) as GameObject;
        movementStarted = true;

        //newGasBubble.transform.position = waypoints[waypointIndex].transform.position;
    }

    public void Update()
    {
        if (movementStarted)
        {
            Move();

            if (newGasBubble.transform.position.x == target.position.x && newGasBubble.transform.position.y == target.position.y)
            {
                movementStarted = false;
                gasCount.IncrementGasCount();
                Debug.Log("Destination reached!");
                Destroy(newGasBubble);

            }
        }

        


    }

    //public void RandomizeMotion()
    //{
    //    timeLeft -= Time.deltaTime;
    //    if (timeLeft <= 0)
    //    {
    //        Vector2 RandomizedMotion = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    //        timeLeft += accelerationTime;
    //    }
    //}

    //public void FixedUpdate()
    //{
    //    rb.AddForce(RandomizedMotion * moveSpeed);
    //}

    public void Move()
    {
        newGasBubble.transform.position = Vector2.MoveTowards(newGasBubble.transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    //public void MoveGasBubble()
    //{
    //    // If Enemy didn't reach last waypoint it can move
    //    // If enemy reached last waypoint then it stops
    //    if (waypointIndex <= waypoints.Length - 1)
    //    {
    //        // Move Enemy from current waypoint to the next one
    //        // using MoveTowards method
    //        newGasBubble.transform.position = Vector2.MoveTowards(newGasBubble.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

    //        // If Enemy reaches position of waypoint he walked towards
    //        // then waypointIndex is increased by 1
    //        // and Enemy starts to walk to the next waypoint
    //        if (newGasBubble.transform.position == waypoints[waypointIndex].transform.position)
    //        {
    //            waypointIndex += 1;
    //        }
    //    }
    //}
}
