using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script by Alex Kobzdej.

public class Health_Bar_UI : MonoBehaviour
{
    public float healthAmount; //Used to test health values. Can be used for in-game health by referencing other scripts.
    public Animator animUI; //The health bar animator.
    public static bool aliveFine; //Boolean for when health is above 75%.
    public static bool aliveCaution; //Boolean for when health is below 75%.
    public static bool aliveDanger; //Boolean for when health is below 25%.
    public static bool deadFlatline; //Boolean for when health reaches zero.
    public Image healthStatus; //The animated set of sprites used to display health.

    public HealthSystem healthValue;


    void Start()
    {
        animUI = GetComponent<Animator>(); //Declaring the animUI as the health bar's animator.
        healthAmount = healthValue.maxHealth_f; 
    }

    void Update()
    {
        healthAmount = healthValue.currentHealth_f;//the healthAmount script is updated to the current health 

        if (healthAmount >= 75f) //If health is above or equal to 75%, disable all booleans except for the aliveFine boolean.
        {
            aliveCaution = false;
            aliveDanger = false;
            deadFlatline = false;
            aliveFine = true;
        }

        if (healthAmount < 75f) //If health is below 75%, disable all booleans except for the aliveCaution boolean.
        {
            aliveFine = false;
            aliveDanger = false;
            deadFlatline = false;
            aliveCaution = true;
        }

        if (healthAmount < 25f) //If health is below 25%, disable all booleans except for the aliveDanger boolean.
        {
            aliveFine = false;
            aliveCaution = false;
            deadFlatline = false;
            aliveDanger = true;
        }

        if (healthAmount <= 0f) //If health reaches zero, disable all booleans except for the deadFlatline boolean.
        {
            aliveFine = false;
            aliveCaution = false;
            aliveDanger = false;
            deadFlatline = true;
        }

        if (aliveFine == true) //If the aliveFine boolean is true, play the "AliveFull" animation and change colour.
        {
            animUI.Play("AliveFull");
            healthStatus.GetComponent<Image>().color = new Color32(96, 202, 0, 255); //Green.
        }
        else if (aliveCaution == true) //If the aliveCaution boolean is true, play the "AliveCaution" animation and change colour.
        {
            animUI.Play("AliveCaution");
            healthStatus.GetComponent<Image>().color = new Color32(215, 214, 30, 255); //Yellow.
        }
        else if (aliveDanger == true) //If the aliveDanger boolean is true, play the "AliveDanger" animation and change colour.
        {
            animUI.Play("AliveDanger");
            healthStatus.GetComponent<Image>().color = new Color32(217, 47, 0, 255); //Red.
        }
        else if (deadFlatline == true) //If the deadFlatline boolean is true, play the "Death" animation and change colour.
        {
            animUI.Play("Death");
            healthStatus.GetComponent<Image>().color = new Color32(0, 0, 0, 255); //Black.
        }
        
    }
}
