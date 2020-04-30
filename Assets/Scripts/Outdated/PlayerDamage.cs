using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    private bool takenDamage = false;
    Health health;
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        health = player.AddComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        if (!takenDamage)
        {
            Debug.Log(amount + " damage and hp " + hp);
            hp -= amount;
            health.setHealth(hp);
            if (hp <= 0)
            {
                Debug.Log("dead");
            }
        }
        else if (takenDamage)
        {

        }
    }
}
