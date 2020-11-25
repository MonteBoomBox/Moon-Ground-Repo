using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GasCount : MonoBehaviour
{
    public GameObject CurrentGasCountGO;
    public GameObject TotalGasCountGO;


    int total;
    int current;

    TextMeshProUGUI CurrentGasCount;
    TextMeshProUGUI TotalGasCount;

    Color completedColor;

    void Start()
    {
        CurrentGasCount = CurrentGasCountGO.GetComponent<TextMeshProUGUI>();
        TotalGasCount = TotalGasCountGO.GetComponent<TextMeshProUGUI>();

        total = int.Parse(TotalGasCount.text);

        completedColor = new Color(0.1803f, 0.8f, 0.4431f, 1f);

    }

    public void IncrementGasCount()
    {
        current = int.Parse(CurrentGasCount.text);
        current += 1;
        CurrentGasCount.text = current.ToString();
    }

    public void Update()
    {
        if (current == total)
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        foreach (Transform word in transform)
        {
            TextMeshProUGUI wordColor = word.GetComponent<TextMeshProUGUI>();
            wordColor.color = completedColor;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }
}
