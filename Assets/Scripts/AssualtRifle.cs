using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssualtRifle : Gun
{
    protected override void Update()
    {
        base.Update();
        //Automatic Fire
        if(Input.GetMouseButton(0) && Time.time - lastFiretime > fireRate)
        {
            lastFiretime = Time.time;
            Fire();
        }
    }
}
