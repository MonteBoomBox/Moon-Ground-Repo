using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentShockBallAmmo;
    public string currentLevel;

    public PlayerData (PlayerController player)
    {
        currentLevel = player.CurrentLevel;
        currentShockBallAmmo = player.currentShockballAMMO;
    }
}
