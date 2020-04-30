using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : PlayerStatus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            itemTeleportTimer = 5.0f;
        }
    }
}
