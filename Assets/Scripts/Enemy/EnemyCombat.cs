using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public GameObject prefab;
    private GameObject effectToSpawn;

    public float fireRate;
    private float nextTimeToFire;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = prefab;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(effectToSpawn) as GameObject;
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;

    }
}
