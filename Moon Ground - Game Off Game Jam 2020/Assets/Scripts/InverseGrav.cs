using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGrav : MonoBehaviour
{

    public static bool gravityInversed = false;

    private bool PlayerIsFlipped;

    // Update is called once per frame
    void Update()
    {
        if (InvertGravity.AbilityIsReady && !PlayerIsFlipped)
        {
            CheckForInversionInput();
        }

        else if (InvertGravity.AbilityIsReady && PlayerIsFlipped)
        {
            CheckForNormalizeInput();
        }

        
    }    

    void CheckForInversionInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            gravityInversed = true;
            PlayerIsFlipped = true;
        }
    }

    void CheckForNormalizeInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            gravityInversed = false;
            PlayerIsFlipped = false;
        }
    }
}
