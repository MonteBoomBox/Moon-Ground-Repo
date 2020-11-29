using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManagement : MonoBehaviour
{
    public int GatePassed;

    GameObject Gate1;
    GameObject Gate2;
    GameObject Gate3;
    GameObject Gate4;

    private bool gate1Moved;
    private bool gate2Moved;
    private bool gate3Moved;
    private bool gate4Moved;

    public GameObject Enemy;


    Vector2 OpenForce;

    void Start()
    {

        Gate1 = transform.GetChild(0).gameObject;
        Gate2 = transform.GetChild(1).gameObject;
        Gate3 = transform.GetChild(2).gameObject;
        Gate4 = transform.GetChild(3).gameObject;

        gate1Moved = false;
        gate2Moved = false;
        gate3Moved = false;
        gate4Moved = false;

        OpenForce = new Vector2(20f, 0f);
        GatePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GatePassed == 1)
        {
            if (!gate1Moved)
            {
                Gate1.transform.position = OpenForce;
                gate1Moved = true;
            }           
        }

        if (GatePassed == 2)
        {
            if (!gate2Moved)
            {
                Gate2.transform.position = OpenForce;
                gate2Moved = true;
            }
        }
        if (GatePassed == 3)
        {
            if (!gate3Moved)
            {
                Gate3.transform.position = OpenForce;
                gate3Moved = true;
            }
        }
        if (GatePassed == 4)
        {
            if (!gate4Moved)
            {
                Gate4.transform.position = OpenForce;
                gate4Moved = true;
            }
        }
    }
}
