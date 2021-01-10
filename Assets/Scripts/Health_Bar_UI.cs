using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script by Alex Kobzdej.

public class Health_Bar_UI : MonoBehaviour
{
    public float healthAmount_f; //Used to test health values. Can be used for in-game health by referencing other scripts.
    public Animator animUI_anim; //The health bar animator.
    public static bool aliveFine_b; //Boolean for when health is above 75%.
    public static bool aliveCaution_b; //Boolean for when health is below 75%.
    public static bool aliveDanger_b; //Boolean for when health is below 25%.
    public static bool deadFlatline_b; //Boolean for when health reaches zero.
    public Image healthStatus_img; //The animated set of sprites used to display health.

    public HealthSystem healthValue_class;

    void Start()
    {
        animUI_anim = GetComponent<Animator>(); //Declaring the animUI_anim as the health bar's animator.
        healthAmount_f = healthValue_class.maxHealth_f; 
    }

    void Update()
    {
        healthAmount_f = healthValue_class.currentHealth_f;//the healthAmount_f script is updated to the current health 

        if (healthAmount_f >= 75f) //If health is above or equal to 75%, disable all booleans except for the aliveFine_b boolean.
        {
            aliveCaution_b = false;
            aliveDanger_b = false;
            deadFlatline_b = false;
            aliveFine_b = true;
        }

        if (healthAmount_f < 75f) //If health is below 75%, disable all booleans except for the aliveCaution_b boolean.
        {
            aliveFine_b = false;
            aliveDanger_b = false;
            deadFlatline_b = false;
            aliveCaution_b = true;
        }

        if (healthAmount_f < 25f) //If health is below 25%, disable all booleans except for the aliveDanger_b boolean.
        {
            aliveFine_b = false;
            aliveCaution_b = false;
            deadFlatline_b = false;
            aliveDanger_b = true;
        }

        if (healthAmount_f <= 0f) //If health reaches zero, disable all booleans except for the deadFlatline_b boolean.
        {
            aliveFine_b = false;
            aliveCaution_b = false;
            aliveDanger_b = false;
            deadFlatline_b = true;
        }

        if (aliveFine_b == true) //If the aliveFine_b boolean is true, play the "AliveFull" animation and change colour.
        {
            animUI_anim.Play("AliveFull");
            healthStatus_img.GetComponent<Image>().color = new Color32(96, 202, 0, 255); //Green.
        }
        else if (aliveCaution_b == true) //If the aliveCaution_b boolean is true, play the "AliveCaution" animation and change colour.
        {
            animUI_anim.Play("AliveCaution");
            healthStatus_img.GetComponent<Image>().color = new Color32(215, 214, 30, 255); //Yellow.
        }
        else if (aliveDanger_b == true) //If the aliveDanger_b boolean is true, play the "AliveDanger" animation and change colour.
        {
            animUI_anim.Play("AliveDanger");
            healthStatus_img.GetComponent<Image>().color = new Color32(217, 47, 0, 255); //Red.
        }
        else if (deadFlatline_b == true) //If the deadFlatline_b boolean is true, play the "Death" animation and change colour.
        {
            animUI_anim.Play("Death");
            healthStatus_img.GetComponent<Image>().color = new Color32(0, 0, 0, 255); //Black.
        }
        
    }
}
