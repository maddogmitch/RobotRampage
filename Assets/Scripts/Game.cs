using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private static Game singleton;

    [SerializeField]
    RobotSpawn[] spawns;
    public int enemiesLeft;
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountDown;
    public bool isGameOver;

    void Start()
    {
        singleton = this;
        SpawnRobots();
    }

    private void SpawnRobots()
    {
        foreach(RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }

    }

    private IEnumerator updateWaveTimer()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountDown--;
            gameUI.SetWaveText(waveCountDown);

            if(waveCountDown == 0)
            {
                SpawnRobots();
                waveCountDown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }
}   
