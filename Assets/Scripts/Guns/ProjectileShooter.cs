using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Controls a fireRate time, projectile comes from CameraBase gameobject
// Ideas and code come from https://www.youtube.com/watch?v=xenW67bXTgM and https://www.youtube.com/watch?v=THnivyG0Mvo
public class ProjectileShooter : MonoBehaviour
{

    public List<GameObject> prefab = new List<GameObject>();
    private GameObject effectToSpawn;

    public float fireRate;
    private float nextTimeToFire;

    /*
    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime;
    private bool isReloading = false;
    */

    public Camera cam;
    public GameObject gun;

    void Start()
    {
        effectToSpawn = prefab[0];
        //currentAmmo = maxAmmo;
    }

   /* void OnEnable()
    {
        isReloading = false;
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if (isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }*/

        //if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            //currentAmmo--;
        }

    }

    void Shoot()
    { 
        GameObject projectile = Instantiate(effectToSpawn) as GameObject;
        projectile.transform.position = gun.transform.position;
        projectile.transform.rotation = cam.transform.rotation;

    }
    /* No longer using ammo system
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        isReloading = false;
    }

    public int getCurrentAmmo()
    {
        return currentAmmo;
    }*/
}
