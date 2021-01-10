using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// do not change !!!
    /// <summary>
    /// Load the Game Scene
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// do not change !!!
    /// <summary>
    /// Load the Main Menu Scene
    /// </summary>
    public void MainMenuPage()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// do not change !!!
    /// <summary>
    /// Load the Settings Scene
    /// </summary>
    public void SettingsPage()
    {
        SceneManager.LoadScene("Settings");
    }

    /// do not change !!!
    /// <summary>
    /// Exit the Game Application.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

}
