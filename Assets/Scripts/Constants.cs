using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This allows for easier use in other scripts as these things will be constant in each script
public class Constants : MonoBehaviour
{
    //Scenes
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";

    //Gun Types
    public const string Pistol = "Pistol";
    public const string Shotgun = "Shotgun";
    public const string AssaultRifle = "AssualtRifle";

    //Robot Types
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";

    //Pickup Types
    public const int PickUpPistolAmmo = 1;
    public const int PickUpAssualtRifleAmmo = 2;
    public const int PickUpShotgunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;

    //Misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    //Keeps track of all possible pickups
    public static readonly int[] AllPickupTypes = new int[5]
    {
        PickUpPistolAmmo,
        PickUpAssualtRifleAmmo,
        PickUpShotgunAmmo,
        PickUpHealth,
        PickUpArmor
    };

}
