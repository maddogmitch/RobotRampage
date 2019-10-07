﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;

    public GameObject activeGun;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Checks which key has been pressed
        if(Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
        }
        else if(Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
        }
        else if(Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}