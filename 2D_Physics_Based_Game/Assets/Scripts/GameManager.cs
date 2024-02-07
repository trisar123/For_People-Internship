using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameState GameState;

    public int starsEarned;

    public static GameManager Instance;

    public Text scoreText;
    public int score;

    public int maxLines = 3;
    public int linesDrawn;

   

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameState = GameState.Start;
    }

    // Update is called once per frame
    void Update()
    {
        StateOfGame();
        UpdateScoreText();
        CheckLinesDrawn();
        
    }
    public void StateOfGame()
    {
        switch (GameState)
        {
            default:
                Debug.LogError("StateOfGame() in GameManager has an issue");
                break;

            case GameState.Start:
                GameState = GameState.Playing;
                break;
            case GameState.Playing:
                break;
            case GameState.Win:
                UnlockLevel();
                break;
            case GameState.Lose:
                break;
        }
    }
    void UnlockLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerPrefs.SetInt("Unlocked Level 2", 1);
            PlayerPrefs.SetInt("StarsEarnedLvl1", starsEarned);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            PlayerPrefs.SetInt("Unlocked Level 3", 1);
            PlayerPrefs.SetInt("StarsEarnedLvl2", starsEarned);
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            PlayerPrefs.SetInt("Unlocked Level 4", 1);
            PlayerPrefs.SetInt("StarsEarnedLvl3", starsEarned);
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            PlayerPrefs.SetInt("Unlocked Level 5", 1);
            PlayerPrefs.SetInt("StarsEarnedLvl4", starsEarned);
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            PlayerPrefs.SetInt("Unlocked Level 6", 1);
            PlayerPrefs.SetInt("StarsEarnedLvl5", starsEarned);
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            PlayerPrefs.SetInt("StarsEarnedLvl6", starsEarned);
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score:" + starsEarned;
    }

    public void CheckLinesDrawn()
    {
        if (linesDrawn < maxLines)
        {
            DrawingManager.Instance.canDraw = true;
        }
        else
        {
            DrawingManager.Instance.canDraw = false;
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

public enum GameState
{
    Start,
    Playing,
    Win,
    Lose
}
