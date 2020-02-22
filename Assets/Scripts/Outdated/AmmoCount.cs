using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{/* NO LONGER USING AMMO
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
        ammo = shooter.getCurrentAmmo();
        if(uitext != null)
        {
            uitext.text = ammo.ToString() + "/" + maxAmmo.ToString();
        }
    }
    */
}
