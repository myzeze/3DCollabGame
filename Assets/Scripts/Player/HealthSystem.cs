using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth_f = 100f;
    public float currentHealth_f;

    public Slider playerHealthSlider_sl;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //initialzing the player health value 
        currentHealth_f = maxHealth_f;
    }

    // Update is called once per frame
    void Update()
    {
        //Health slider gets updated every frame
        playerHealthSlider_sl.value = (currentHealth_f / maxHealth_f);

        Dead();
    }

    void Dead()
    {
        if (currentHealth_f <= 0)
        {
            //Gameplay stops
            Time.timeScale = 0;
            //GameOver screen comes up

        }
    }
}
