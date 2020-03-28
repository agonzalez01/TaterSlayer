using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
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
        Debug.Log("Pause Button");
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Pause Button");
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenu.SetActive(false);
    }

    public void GetSettings()
    {
        //Saves the current scene
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("SettingsMenu");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
