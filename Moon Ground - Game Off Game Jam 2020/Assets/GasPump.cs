using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPump : MonoBehaviour
{
    public GameObject GasBubblePrefab;

    public Transform spawnPoint;

    public void SpawnGasBubble()
    {
        Instantiate(GasBubblePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
