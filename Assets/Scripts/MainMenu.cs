﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        Debug.Log("Test");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
