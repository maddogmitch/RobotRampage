using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assualtRifleAmmo = 50;

    //maps the guns type to its ammo count
    public Dictionary<string, int> tagToAmmo;

    //makes each type a key and sets it to the approtiate value
    void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
        {
            {Constants.Pistol , pistolAmmo },
            {Constants.Shotgun , shotgunAmmo },
            {Constants.AssaultRifle , assualtRifleAmmo },
        };
    }

    //adds ammunition to the appropriate gun type
    public void AddAmmo(string tag, int ammo)
    {
        if(!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        tagToAmmo[tag] += ammo;
    }

    //Returns true if gun has ammo
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        return tagToAmmo[tag] > 0;
    }

    //returns the bullet count
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        return tagToAmmo[tag];
    }

    //Consumes the bullet
    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        tagToAmmo[tag]--;
        gameUI.SetAmmoText(tagToAmmo[tag]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
