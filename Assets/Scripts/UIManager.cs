using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timer;
    public Text points;

    public Text correctBricks;
    public Text incorrectBricks;
    public Text totalPoints;

    public GameObject gameOverPanel;
    public GameObject gameStartPanel;

    private static string _time;
    private static string _point;
    private static string _correctBricks;
    private static string _incorrectBricks;

    private void Start()
    {
        gameStartPanel.SetActive(true);
    }
    public static void UpdateTimer(string time)
    {
        _time = time;
    }

    public static void UpdatePoints(string point)
    {
        _point = point;
    }

    private void Update()
    {
        timer.text = _time;
        points.text = _point;
        if (GameManager.gameOver)
        {
            GameOver();
            correctBricks.text = _correctBricks;
            incorrectBricks.text = _incorrectBricks;
            totalPoints.text = _point;
        }

        if (GameManager.gameStart && !GameManager.gameOver)
        {
            StartGame();
        }
    }

    public static void UpdateCorrectBricks(List<string> bricks)
    {
        string correctBrickText = "You have collected: ";

        foreach(var brick in bricks)
        {
            correctBrickText += brick + " ";
        }

        correctBrickText += " correctly.";

        _correctBricks = correctBrickText;
        if (bricks.Count == 0)
            _correctBricks = "There were no correct bricks";
    }

    public static void UpdateIncorrectBricks(List<string> bricks)
    {
        string incorrectBrickText = "You have collected: ";

        foreach (var brick in bricks)
        {
            incorrectBrickText += brick + " ";
        }

        incorrectBrickText += " incorrectly.";

        _incorrectBricks = incorrectBrickText;
        if (bricks.Count == 0)
            _incorrectBricks = "There were no incorrect bricks";
    }

    void StartGame()
    {
        gameOverPanel.SetActive(false);
        gameStartPanel.SetActive(false);
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
