using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas PauseCanva;
    public bool paused;

    void Start()
    {

        paused = false;
        PauseCanva.enabled = false;
        Time.timeScale = 1f;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {

            PauseCanva.enabled = true;
            paused = true;
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            
            PauseCanva.enabled = false;
            paused = false;
            Time.timeScale = 1f;
        }
    }

    public void Exit()
    {

        Application.Quit();
    }

    public void Resstart()
    {
        
        SceneManager.LoadScene(0);
    }
    
    public void Resume()
    {

        PauseCanva.enabled = false;
        paused = false;
        Time.timeScale = 1f;
    }

    public void Github()
    {
        
        Application.OpenURL("https://github.com/dazaizer0");
    }

    public void Youtube()
    {
        
        Application.OpenURL("https://www.youtube.com/@dazaizer0");
    }
}
