using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{

    EnemyHealth EnemyIsDead;

    void Start()
    {
        EnemyIsDead = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyIsDead.isDead)
        {
            GameObject.FindGameObjectWithTag("GateManager").GetComponent<GateManagement>().GatePassed += 1;
        }
    }
}
