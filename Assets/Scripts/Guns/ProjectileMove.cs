using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place script on projectile type, allows for different damage/speeds/range, Works for at least machinegun
// Ideas/Code comes from https://www.youtube.com/watch?v=xenW67bXTgM and https://www.youtube.com/watch?v=DEtZUeVY9qk
public class ProjectileMove : ProjectileStat
{

    void Start()
    {
        initialDistance = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Speed != 0)
        {
            transform.position += transform.forward * (Speed * Time.deltaTime);
        }

        float currentDistance = Vector3.Distance(transform.position, initialDistance);
        if (currentDistance > Range)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision co)
    {
        Destroy(gameObject);
        EnemyController target = co.transform.GetComponent<EnemyController>();
        PlayerController player = co.transform.GetComponent<PlayerController>();
        if(target != null && hasCollide == false)
        {
            hasCollide = true;
            Debug.Log(target.name + " took " + Damage + " damage");
            target.TakeDamage(Damage);
        }
        if (player != null && hasCollide == false)
        {
            hasCollide = true;
            Debug.Log(player + " took " + Damage + " damage");
            player.TakeDamage((int)Damage);
        }
        
    }
}
