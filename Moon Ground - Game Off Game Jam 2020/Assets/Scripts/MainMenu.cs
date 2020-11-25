using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    PlayerController controller;
    private int levelToLoad;

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
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

    //public void LoadPlayerLevel()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    levelToLoad = controller.CurrentLevel;
    //    controller.CurrentLevel = data.currentLevel;
    //    SceneManager.LoadScene(levelToLoad);
    //}
}
