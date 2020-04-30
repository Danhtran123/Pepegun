using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //variables for stat adjustments
    public float currentSpeedItem;
    private float maxSpeed = 2.5f;
    public float currentJumpItem;
    private float maxJump = 5.0f;
    
    //variables for kill tracker
    public int maxKillCounter;
    private int killCount;

    public Text score;
    bool isQuitting = false;

    public static int playerScore = 0;

    private void Start()
    {
        playerScore = 0;
    }
    public void AddSpeed(float item)
    {
        if(currentSpeedItem >= maxSpeed)
        {
            currentSpeedItem = maxSpeed;
        }
        else
        {
            currentSpeedItem += item;
        }
    }
    
    public void AddJump(float item)
    {
        if(currentJumpItem >= maxJump)
        {
            currentJumpItem = maxJump;
        }
        else
        {
            currentJumpItem += item;
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void AddScore(int value)
    {
        if(!isQuitting && !PauseMenu.isPaused)
        {
            playerScore += value;
            score.text = "Score: " + playerScore;
        }
    }
}
