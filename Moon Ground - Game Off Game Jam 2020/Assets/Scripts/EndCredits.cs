using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{

    public GameObject CreditsText;

    public float moveSpeed = 10f;

    private AudioSource creditsMusic;

    void Start()
    {
        creditsMusic = GetComponent<AudioSource>();
        creditsMusic.Play();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
