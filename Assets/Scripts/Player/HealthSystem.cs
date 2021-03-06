﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by Oluwademilade Ayannusi
public class HealthSystem : MonoBehaviour
{
    public float maxHealth_f = 100f;
    public float currentHealth_f;

    public GameObject player_go;
    public GameObject gameOverScreen_go;

    // Start is called before the first frame update
    void Start()
    {
        player_go.GetComponent<PlayerInteraction>().enabled = true;
        player_go.GetComponent<PlayerPauseMenu>().enabled = true;
        //initialzing the player health value 
        currentHealth_f = maxHealth_f;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    void Dead()
    {
        if (currentHealth_f <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            player_go.GetComponent<PlayerInteraction>().enabled = false;
            player_go.GetComponent<PlayerPauseMenu>().enabled = false;
            gameOverScreen_go.SetActive(true);

        }
    }
}
