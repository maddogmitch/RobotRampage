using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    protected override void Update()
    {
        base.Update();
        //Shotgun and Pistol have semi-auto fire rate
        if(Input.GetMouseButton(0) && (Time.time - lastFiretime) > fireRate)
        {
            //checks if enough time has passed between shots to fire the gun
            lastFiretime = Time.time;
            Fire();
        }
    }
}
