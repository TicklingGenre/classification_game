using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public int gameTimeInSeconds = 120;
    public static bool gameOver;
    public static bool gameStart;
    public List<GameObject> disableList;
    public static List<string> correctBricks;
    public static List<string> incorrectBricks;


    private static int _points = 0;

    [SerializeField]
    private int _timeTillGameEnd;
    private int _timeStamp;

    private void Start()
    {
        ResetValues();
    }

    private void Update()
    {
        if(Time.time - _timeStamp >= 1 && !gameOver)
        {
            //Debug.Log("one Second Passed");
            UpdateTimer(--_timeTillGameEnd);
            _timeStamp = (int) Time.time;
        }

        if(_timeTillGameEnd <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        UIManager.UpdateCorrectBricks(correctBricks);
        UIManager.UpdateIncorrectBricks(incorrectBricks);
        Time.timeScale = 0;
    }
    static void UpdateTimer(int time)
    {
        UIManager.UpdateTimer(time.ToString());
    }

    public static void AddPoints(bool correctBin)
    {
        if (correctBin)
        {
            _points += 10;
        }
        else
        {
            _points -= 2;
        }
        UpdatePoints(_points);
    }

    static void UpdatePoints(int points)
    {
        UIManager.UpdatePoints(points.ToString());
    }

    public static void StartGame()
    {
        gameStart = true;
        Time.timeScale = 1;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        ResetValues();
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
     void ResetValues()
    {
        _points = 0;
        _timeTillGameEnd = gameTimeInSeconds;
        _timeStamp = (int)Time.time;
        UpdateTimer(_timeTillGameEnd);
        UpdatePoints(_points);
        gameOver = false;
        gameStart = false;
        correctBricks = new List<string>();
        incorrectBricks = new List<string>();
        Time.timeScale = 0;
    }
}
