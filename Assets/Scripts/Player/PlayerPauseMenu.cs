using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPauseMenu : MonoBehaviour
{
    [Header("UI Variables")]
    public GameObject PauseMenu_go;    
    private static bool p_gameIsPaused_b;

    void Start()
    {
        Cursor.visible = true;
        GameObject playerComponent_go = GameObject.Find("Player");
        playerComponent_go.GetComponent<Player1Movement>().enabled = true;
    }

    void Update()
    {
        /// 
        if (Input.GetButtonDown("PauseMenu"))
        {
            p_gameIsPaused_b = !p_gameIsPaused_b;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (p_gameIsPaused_b)
        {
            Time.timeScale = 0f;
            Paused();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            GameObject getPlayerMoveScript_go = GameObject.Find("Player");
            getPlayerMoveScript_go.GetComponent<Player1Movement>().enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            ResumeGame();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject getPlayerMoveScript_go = GameObject.Find("Player");
            getPlayerMoveScript_go.GetComponent<Player1Movement>().enabled = true;
        }
    }

    void ResumeGame()
    {
        PauseMenu_go.SetActive(false);
    }

    void Paused()
    {
        PauseMenu_go.SetActive(true);
        p_gameIsPaused_b = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        ResumeGame();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject getPlayerMoveScript_go = GameObject.Find("Player");
        getPlayerMoveScript_go.GetComponent<Player1Movement>().enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
