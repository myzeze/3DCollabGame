using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    
    public void playgame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void settingspage()
    {
        SceneManager.LoadScene("Settings");
    }

    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

}
