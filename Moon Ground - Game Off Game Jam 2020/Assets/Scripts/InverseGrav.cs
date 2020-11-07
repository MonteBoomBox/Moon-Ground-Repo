using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGrav : MonoBehaviour
{

    public static bool gravityInversed = false;    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gravityInversed = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            gravityInversed = false;
        }
    }
}
