using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummoner : EnemyCombat
{

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = prefab;
        attackTime = Random.Range(minAtkTime, maxAtkTime);
        attackTimeHolder = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            attackTime = attackTimeHolder;
            Summon();
        }
    }

    void Summon()
    {
        GameObject summon = Instantiate(effectToSpawn) as GameObject;
        summon.transform.position = transform.position + transform.forward;
    }

    //if player gets in range melee attack , if in range, attack instead of summoning?
    void Attack()
    {

    }
}
