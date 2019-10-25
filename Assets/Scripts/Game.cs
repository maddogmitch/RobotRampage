using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static Game singleton;
    public GameObject gameOverPanel;

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
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountDown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
        SpawnRobots();
    }

    private void SpawnRobots()
    {
        foreach(RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
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

    //Removes robots from the count and updates the UI
    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        //Bonus for clearing the wave before timer is done
        if(singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }

    //Frees the mouse when game is over
    public void OnGUI()
    {
        if (isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    //Is called when the game is over it freezes the robots and disables the controls and shows the gameover panel
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPanel.SetActive(true);
    }
    //Restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(true);
    }
    //Exits the game
    public void Exit()
    {
        Application.Quit();
    }
    //Brings you to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
    }

}   
