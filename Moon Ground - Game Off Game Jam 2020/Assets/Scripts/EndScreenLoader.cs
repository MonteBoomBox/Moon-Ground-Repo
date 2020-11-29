using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 2f;

    void Start()
    {
        
    }

    public void LoadEndCredits()
    {
        StartCoroutine(LoadCredits(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadCredits(int levelIndex)
    {
        transition.SetTrigger("End");

        SceneManager.LoadScene(levelIndex);

        yield return new WaitForSeconds(transitionTime);         
    }
}
