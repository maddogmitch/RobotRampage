using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;

    public GameObject activeGun;

    [SerializeField]
    Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        //Initilizes the starting gun as pistol
        activeWeaponType = Constants.Pistol;

        activeGun = pistol;
    }

    //Loads the weapons and turns them off till activated in the code below
    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }

    // Update is called once per frame
    void Update()
    {
        //Checks which key has been pressed
        if(Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateRecticle();
        }
        else if(Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateRecticle();
        }
        else if(Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateRecticle();
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
