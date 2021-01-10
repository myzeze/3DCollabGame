using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreSystem : MonoBehaviour
{
    public Text scoreText;

    public int playerScore_f;

    // Start is called before the first frame update
    void Start()
    {
        playerScore_f = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //The UI getting updated every frame
        scoreText.text = playerScore_f.ToString();

        scoreIncrease();
    }

    void scoreIncrease()
    {
        //Make the score go up with an if statement based on the task completed
    }
}
