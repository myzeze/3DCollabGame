using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    //do not change !!!
    public void playgame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    //do not change !!!
    public void settingspage()
    {
        SceneManager.LoadScene("Settings");
    }

    //do not change !!!
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

}
