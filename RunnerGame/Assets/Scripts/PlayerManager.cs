using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int score;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        score = 0;//number of Coin
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            
        }

        //Start Game
        if (SwipeManager.tap /*&& !isGameStarted*/)//when we tap  on the sceen 
        {
            isGameStarted = true;//  the game start
            Destroy(startingText);//and we remove the startingText
        }
    }
}
