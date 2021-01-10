using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject PauseMenu;
    public GameObject Cam;




    void Start()
    {
        Cursor.visible = true;
        GameObject varGameObject = GameObject.Find("Player");
        varGameObject.GetComponent<Player1Movement>().enabled = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }


    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Paused();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            GameObject varGameObject = GameObject.Find("Player");
            varGameObject.GetComponent<Player1Movement>().enabled = false;
            


            


        }
        else
        {
            Time.timeScale = 1;
            ResumeGame();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject varGameObject = GameObject.Find("Player");
            varGameObject.GetComponent<Player1Movement>().enabled = true;

        }
    }
    void ResumeGame()
    {
        PauseMenu.SetActive(false);

    }

    void Paused()
    {
        PauseMenu.SetActive(true);
        gameIsPaused = true;
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        

        //Debug.Log("testLoadMainMenuButton");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        ResumeGame();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject varGameObject = GameObject.Find("Player");
        varGameObject.GetComponent<Player1Movement>().enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
