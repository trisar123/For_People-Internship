﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class BackToMain : MonoBehaviour {
	public void BackToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}