using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelToLoad;

   
    public void nextlevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
