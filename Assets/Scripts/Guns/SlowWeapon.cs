using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SlowWeapon : MonoBehaviour
{
    public float slowStrength;

    void OnCollisionEnter(Collision co)
    {
        NavMeshAgent target = co.transform.GetComponent<NavMeshAgent>();
        if(target != null)
        {
            Debug.Log(target.name);
            target.speed /= slowStrength;
        }
    }
}
