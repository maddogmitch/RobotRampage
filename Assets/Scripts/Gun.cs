using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    protected float lastFiretime;

    // Start is called before the first frame update
    void Start()
    {
        //set last fire time so player can start shooting as soon as the game starts
        lastFiretime = Time.time - 10;
    }

    protected virtual void Update()
    {

    }

    protected void Fire()
    {
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
