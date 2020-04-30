using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private int value = 1;
    private int currentHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentHealth = FindObjectOfType<Health>().GetHealth();
            FindObjectOfType<Health>().setHealth(currentHealth+value);
            Destroy(gameObject);
        }
    }
}
