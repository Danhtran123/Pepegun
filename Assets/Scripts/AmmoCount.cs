using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text uitext;

    private int ammo;
    private int maxAmmo;

    ProjectileShooter shooter;

    void Start()
    {
        GameObject gun = GameObject.Find("MachineGun");
        shooter = gun.GetComponent<ProjectileShooter>();
        maxAmmo = shooter.maxAmmo;
    }

// Update is called once per frame
    void Update()
    {
        ammo = shooter.currentAmmo;
        if(uitext != null)
        {
            uitext.text = ammo.ToString() + "/" + maxAmmo.ToString();
        }
    }
}
