﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;
    public Game game;
    public AudioClip playerDead;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    //Takes incoming damage and puts it through the following if statements
    public void TakeDamage(int amount) 
    {
        int healthDamage = amount;

        if(armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;
            //If there is still armor no need to process
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                gameUI.SetArmorText(armor);
                return;
            }
            armor = 0;
            gameUI.SetArmorText(armor);
        }

        health -= healthDamage;
        gameUI.SetHealthText(health);

        if (health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
        }
    }

    private void pickupHealth()
    {
        health += 50;
        if(health > 200)
        {
            health = 200;
        }
        gameUI.SetPickUpText("Health picked up +50 Health");
        gameUI.SetHealthText(health);
    }

    private void pickupArmor()
    {
        armor += 15;
        gameUI.SetPickUpText("Armor Picked Up +15 armor");
        gameUI.SetArmorText(armor);
    }

    private void pickupAssualtRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.SetPickUpText("Assualt Rifle ammo piked up + 50");
        if(gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.SetPickUpText("Pistol ammo picked up + 20");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        gameUI.SetPickUpText("Shotgun ammo picked up +10");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }

    public void PickUpItem(int pickupType)
    {
        switch(pickupType)
        {
            case Constants.PickUpArmor:
                pickupArmor();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssualtRifleAmmo:
                pickupAssualtRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
