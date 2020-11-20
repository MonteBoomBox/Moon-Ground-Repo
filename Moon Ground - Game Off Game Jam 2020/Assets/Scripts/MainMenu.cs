using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        BroadcastMessage("LoadPlayerData");
        PauseMenu.GameIsPaused = false;
    }

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
