﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] robots;

    private int timeSpawned;
    private int healthBonus = 0;

    public void SpawnRobot()
    {
        timeSpawned++;
        healthBonus += 1 * timeSpawned;
        GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
        robot.transform.position = transform.position;
        robot.GetComponent<Robot>().health += healthBonus;
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
