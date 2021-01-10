using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created by Oluwademilade Ayannusi
public class PlayerScoreSystem : MonoBehaviour
{
    public Text scoreText_txt;

    public int playerScore_i;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //The UI getting updated every frame
        scoreText_txt.text = playerScore_i.ToString();
    }

    public void scoreIncrease(int _scoreToAdd)
    {
        playerScore_i += _scoreToAdd;
    }
}
