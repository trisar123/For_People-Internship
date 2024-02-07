using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class TitleMenu : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("tutorial");
        
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}