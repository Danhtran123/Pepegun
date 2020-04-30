using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Controls a fireRate time, projectile comes from CameraBase gameobject
// Ideas and code come from https://www.youtube.com/watch?v=xenW67bXTgM and https://www.youtube.com/watch?v=THnivyG0Mvo
public class ProjectileShooter : MonoBehaviour
{

    public GameObject prefab;
    private GameObject effectToSpawn;

    public float fireRate;
    private float nextTimeToFire;

    public Camera cam;
    public GameObject gun;

    void Start()
    {
        effectToSpawn = prefab;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    { 
        GameObject projectile = Instantiate(effectToSpawn) as GameObject;
        projectile.transform.position = transform.position;
        projectile.transform.rotation = cam.transform.rotation;

    }

}
