﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void LoadFinalCredits()
    {
        GetComponentInParent<EndScreenLoader>().LoadEndCredits();
    }
}
