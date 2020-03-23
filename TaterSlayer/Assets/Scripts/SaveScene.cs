using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Grabs current scene and puts it in the PlayerPrefs for the settings menu
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }
}
