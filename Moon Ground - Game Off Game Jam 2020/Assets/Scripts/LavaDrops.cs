using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrops : MonoBehaviour
{
    private InverseGrav gravity;

    Vector2 RandomSpawnPos;

    public float YOffset = 2f;

    public float moveSpeed = 5f;

    public float respawnTime = 1f;

    public GameObject lavaDropPrefab;
    GameObject newLavaDrop;

    private bool hasStartedCoroutine = false;

    private float inversedGravScale = -1f;
    private float normalizedGravScale = 1f;

    public Transform leftMostPos;
    public Transform rightMostPos;

    IEnumerator LavaDrop;

    public void Start()
    {    
        gravity = this.GetComponent<InverseGrav>();
        RandomSpawnPos.x = Random.Range(25, 50);
        LavaDrop = LavaDropsWave();
    }

    public void Update()
    {
        if (InverseGrav.gravityInversed == true)
        {
            if (hasStartedCoroutine == false)
            {
                StartCoroutine(LavaDrop);
                hasStartedCoroutine = true;
            }
        }

        else if (InverseGrav.gravityInversed == false)
        {
            if (hasStartedCoroutine == true)
            {
                StopCoroutine(LavaDrop);
                hasStartedCoroutine = false;
            }            
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SpawnLavaDrop()
    {
        newLavaDrop = Instantiate(lavaDropPrefab) as GameObject;
        newLavaDrop.transform.position = new Vector2(Random.Range(leftMostPos.position.x, rightMostPos.position.x), transform.position.y);
        Rigidbody2D rb = newLavaDrop.GetComponent<Rigidbody2D>();
        rb.gravityScale = inversedGravScale;
    }

    IEnumerator LavaDropsWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnLavaDrop();
        }
    }

}
