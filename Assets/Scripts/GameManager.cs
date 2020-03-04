using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float currentSpeedItem;
    private float maxSpeed = 2.5f;
    public float currentJumpItem;
    private float maxJump = 5.0f;

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
}
