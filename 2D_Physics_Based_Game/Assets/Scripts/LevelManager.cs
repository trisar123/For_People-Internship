using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Levels")]
    public Button[] levels;

    [Header("Unlocked Level")]
    public int unlockedLevel2 = 0;
    public int unlockedLevel3 = 0;
    public int unlockedLevel4 = 0;
    public int unlockedLevel5 = 0;
    public int unlockedLevel6 = 0;

    [Header("Stars Earned")]
    public int starsEarned1 = 0;
    public GameObject[] starsEarnedLvl1;

    public int starsEarned2 = 0;
    public GameObject[] starsEarnedLvl2;

    public int starsEarned3 = 0;
    public GameObject[] starsEarnedLvl3;

    public int starsEarned4 = 0;
    public GameObject[] starsEarnedLvl4;

    public int starsEarned5 = 0;
    public GameObject[] starsEarnedLvl5;

    public int starsEarned6 = 0;
    public GameObject[] starsEarnedLvl6;

    [Header("Use Debug")]
    public bool useDebug = false;

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        unlockedLevel2 = PlayerPrefs.GetInt("Unlocked Level 2");
        unlockedLevel3 = PlayerPrefs.GetInt("Unlocked Level 3");
        unlockedLevel4 = PlayerPrefs.GetInt("Unlocked Level 4");
        unlockedLevel5 = PlayerPrefs.GetInt("Unlocked Level 5");
        unlockedLevel6 = PlayerPrefs.GetInt("Unlocked Level 6");

        if (PlayerPrefs.GetInt("StarsEarnedLvl1") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl1", 3);
        }

        if (PlayerPrefs.GetInt("StarsEarnedLvl2") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl2", 3);
        }
        if (PlayerPrefs.GetInt("StarsEarnedLvl3") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl3", 3);
        }
        if (PlayerPrefs.GetInt("StarsEarnedLvl4") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl4", 3);
        }
        if (PlayerPrefs.GetInt("StarsEarnedLvl5") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl5", 3);
        }
        if (PlayerPrefs.GetInt("StarsEarnedLvl6") > 3)
        {
            PlayerPrefs.SetInt("StarsEarnedLvl6", 3);
        }

        starsEarned1 = PlayerPrefs.GetInt("StarsEarnedLvl1");
        starsEarned2 = PlayerPrefs.GetInt("StarsEarnedLvl2");
        starsEarned3 = PlayerPrefs.GetInt("StarsEarnedLvl3");
        starsEarned4 = PlayerPrefs.GetInt("StarsEarnedLvl4");
        starsEarned5 = PlayerPrefs.GetInt("StarsEarnedLvl5");
        starsEarned6 = PlayerPrefs.GetInt("StarsEarnedLvl6");
    }
    // Update is called once per frame
    void Update()
    {
        UnlockedLevel();
        StarsEarned();
        UseDebug();
    }
    //sets the amount of owanges to how much was obtained for that level
    void StarsEarned()
    {
        //lvl 1
        starsEarnedLvl1[0].SetActive(false);
        starsEarnedLvl1[1].SetActive(false);
        starsEarnedLvl1[2].SetActive(false);
        for (int i = 0; i < starsEarned1; i++)
        {
            starsEarnedLvl1[i].SetActive(true);
        }
        //lvl2
        starsEarnedLvl2[0].SetActive(false);
        starsEarnedLvl2[1].SetActive(false);
        starsEarnedLvl2[2].SetActive(false);
        for (int i = 0; i < starsEarned2; i++)
        {
            starsEarnedLvl2[i].SetActive(true);
        }
        //lvl 3
        starsEarnedLvl3[0].SetActive(false);
        starsEarnedLvl3[1].SetActive(false);
        starsEarnedLvl3[2].SetActive(false);
        for (int i = 0; i < starsEarned3; i++)
        {
            starsEarnedLvl3[i].SetActive(true);
        }
        //lvl 4
        starsEarnedLvl4[0].SetActive(false);
        starsEarnedLvl4[1].SetActive(false);
        starsEarnedLvl4[2].SetActive(false);
        for (int i = 0; i < starsEarned4; i++)
        {
            starsEarnedLvl4[i].SetActive(true);
        }
        //lvl 5
        starsEarnedLvl5[0].SetActive(false);
        starsEarnedLvl5[1].SetActive(false);
        starsEarnedLvl5[2].SetActive(false);
        for (int i = 0; i < starsEarned5; i++)
        {
            starsEarnedLvl5[i].SetActive(true);
        }
        //lvl 6
        starsEarnedLvl6[0].SetActive(false);
        starsEarnedLvl6[1].SetActive(false);
        starsEarnedLvl6[2].SetActive(false);
        for (int i = 0; i < starsEarned6; i++)
        {
            starsEarnedLvl6[i].SetActive(true);
        }
    }
    //unlocks lvl depending on if the level's PlayerPref is 1
    void UnlockedLevel()
    {
        //only lvl 1
        //if level one finished level two will be finished 
        if (unlockedLevel2 == 0 && unlockedLevel3 == 0 && unlockedLevel4 == 0 && unlockedLevel5 == 0 && unlockedLevel6 == 0)
        {
            levels[0].interactable = true;
            levels[1].interactable = false;
            levels[2].interactable = false;
            levels[3].interactable = false;
            levels[4].interactable = false;
            levels[5].interactable = false;
        }
        //only lvl 2
        else if (unlockedLevel2 == 1 && unlockedLevel3 == 0 && unlockedLevel4 == 0 && unlockedLevel5 == 0 && unlockedLevel6 == 0)
        {
            levels[0].interactable = true;
            levels[1].interactable = true;
            levels[2].interactable = false;
            levels[3].interactable = false;
            levels[4].interactable = false;
            levels[5].interactable = false;
        }
        //only lvl 3
        else if (unlockedLevel2 == 1 && unlockedLevel3 == 1 && unlockedLevel4 == 0 && unlockedLevel5 == 0 && unlockedLevel6 == 0)
        {
            levels[0].interactable = true;
            levels[1].interactable = true;
            levels[2].interactable = true;
            levels[3].interactable = false;
            levels[4].interactable = false;
            levels[5].interactable = false;
        }
        //only lvl 4
        else if (unlockedLevel2 == 1 && unlockedLevel3 == 1 && unlockedLevel4 == 1 && unlockedLevel5 == 0 && unlockedLevel6 == 0)
        {
            levels[0].interactable = true;
            levels[1].interactable = true;
            levels[2].interactable = true;
            levels[3].interactable = true;
            levels[4].interactable = false;
            levels[5].interactable = false;
        }
        //only lvl 5
        else if (unlockedLevel2 == 1 && unlockedLevel3 == 1 && unlockedLevel4 == 1 && unlockedLevel5 == 1 && unlockedLevel6 == 0)
        {
            levels[0].interactable = true;
            levels[1].interactable = true;
            levels[2].interactable = true;
            levels[3].interactable = true;
            levels[4].interactable = true;
            levels[5].interactable = false;
        }
        else if (unlockedLevel2 == 1 && unlockedLevel3 == 1 && unlockedLevel4 == 1 && unlockedLevel5 == 1 && unlockedLevel6 == 1)
        {
            levels[0].interactable = true;
            levels[1].interactable = true;
            levels[2].interactable = true;
            levels[3].interactable = true;
            levels[4].interactable = true;
            levels[5].interactable = true;
        }
    }

    void UseDebug()
    {
        //reset the oranges thingies
        if (Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ChosenLevel(string level)
    {
        switch (level)
        {
            default:
                Debug.LogError("ChosenLevel() in LevelManager has an issue");
                break;

            case "Level1":
            case "Level2":
            case "Level3":
            case "Level4":
            case "Level5":
            case "Level6":
                SceneManager.LoadScene(level);
                break;
        }
    }
}
//only lvl 6
