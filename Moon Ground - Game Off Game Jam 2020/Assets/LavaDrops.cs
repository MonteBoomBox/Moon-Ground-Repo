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

    private bool hasStartedCoroutine = false;

    public void Start()
    {
        gravity = GetComponent<InverseGrav>();

        RandomSpawnPos = new Vector2(Random.Range(25, 50), transform.position.y + YOffset);
    }

    public void Update()
    {
        if (gravity.gravityInversed == true)
        {
            if (!hasStartedCoroutine)
            {
                StartCoroutine(LavaDropsWave());
                hasStartedCoroutine = true;                
            }
        }

        else if (gravity.gravityInversed == false)
        {
            Debug.Log("STOP!");
            StopCoroutine(LavaDropsWave());
        }
    }

    IEnumerator LavaDropsWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnLavaDrop();
        }
    }

    public void SpawnLavaDrop()
    {
        GameObject newLavaDrop = Instantiate(lavaDropPrefab, RandomSpawnPos, transform.rotation) as GameObject;
        newLavaDrop.GetComponent<Rigidbody2D>().velocity = Vector2.up * moveSpeed;
    }
    
}
