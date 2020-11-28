using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeEntry : MonoBehaviour
{
    GameObject mainCamera;

    public void TeleportPlayerToMeme()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 memeView = new Vector3(200f, 0f, -10f);
        mainCamera.transform.position = memeView;
    }

    public void TeleportPlayerToGame()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 memeView = new Vector3(0f, 0f, -10f);
        mainCamera.transform.position = memeView;
    }
}
