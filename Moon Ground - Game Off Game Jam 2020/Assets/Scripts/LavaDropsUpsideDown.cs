using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDropsUpsideDown : MonoBehaviour
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
            if (hasStartedCoroutine == true)
            {
                StopCoroutine(LavaDrop);
                hasStartedCoroutine = false;
            }
        }

        else if (InverseGrav.gravityInversed == false)
        {
            if (hasStartedCoroutine == false)
            {
                StartCoroutine(LavaDrop);
                hasStartedCoroutine = true;
            }
        }
    }

    public void SpawnLavaDrop()
    {
        newLavaDrop = Instantiate(lavaDropPrefab) as GameObject;
        newLavaDrop.transform.position = new Vector2(Random.Range(leftMostPos.position.x, rightMostPos.position.x), transform.position.y);
        newLavaDrop.transform.Rotate(0f, 0f, 180f);
        Rigidbody2D rb = newLavaDrop.GetComponent<Rigidbody2D>();
        rb.gravityScale = normalizedGravScale;
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
