using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public List<GameObject> prefab = new List<GameObject>();
    private GameObject effectToSpawn;

    public float fireRate;
    private float nextTimeToFire;

    public int maxAmmo;
    public int currentAmmo;

    public Camera cam;

    void Start()
    {
        effectToSpawn = prefab[0];
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            currentAmmo--;
        }

        if(Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0)
        {
            Reload();
        }

    }

    void Shoot()
    { 
        GameObject projectile = Instantiate(effectToSpawn) as GameObject;
        projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
        projectile.transform.rotation = cam.transform.rotation;

    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
