using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public GameObject prefab;
    protected GameObject effectToSpawn;

    public float minAtkTime;
    public float maxAtkTime;

    protected float attackTime;
    protected float attackTimeHolder;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = prefab;
        attackTime = Random.Range(minAtkTime,maxAtkTime);
        attackTimeHolder = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime -= Time.deltaTime;
        if(attackTime <= 0){
            attackTime = attackTimeHolder;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(effectToSpawn) as GameObject;
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.parent.gameObject.transform.rotation;

    }
}
