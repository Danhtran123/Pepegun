using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleItem : PlayerStatus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            invincible = true;
            iFrameTimer = 0;
            FindObjectOfType<PlayerController>().resetIFrame();
        }
    }
}
