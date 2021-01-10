using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created by Oluwademilade Ayannusi
public class PlayerScoreSystem : MonoBehaviour
{
    public static PlayerScoreSystem instance_class;
    public Text scoreText_txt;

    private int p_playerScore_i;

    // Start is called before the first frame update
    private void Start()
    {
        instance_class = this;
    }

    // Update is called once per frame
    private void Update()
    {
        //The UI getting updated every frame
        scoreText_txt.text = "Score: " + p_playerScore_i.ToString();
    }

    public void scoreIncrease(int _scoreToAdd)
    {
        p_playerScore_i += _scoreToAdd;
    }
}
