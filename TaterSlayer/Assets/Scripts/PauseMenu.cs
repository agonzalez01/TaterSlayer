﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }

    public void Pause()
    {

        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Resume()
    {

        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void GetSettings()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}