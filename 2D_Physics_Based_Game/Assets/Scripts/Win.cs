using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject winCon;
    public bool WinLevel;
    public GameObject VictoryScreen;
    public bool hasCollided;
    public Button nextLevel;

    public AudioSource LevelComplete;

    public void Start()
    {
        WinLevel = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Weight>() && !hasCollided)
        {
            WinLevel = true;
            GameManager.Instance.GameState = GameState.Win;

            LevelComplete.Play();
            VictoryScreen.SetActive(true);
            Destroy(winCon);
        }
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level4");
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            SceneManager.LoadScene("Level5");
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            SceneManager.LoadScene("Level6");
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            nextLevel.interactable = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
