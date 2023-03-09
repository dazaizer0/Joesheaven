using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToHome : MonoBehaviour
{

    public bool pause = false;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            SceneManager.LoadScene("Home");
        }
    }
    public void Exit()
    {

        Application.Quit();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {

            Time.timeScale = 0f;
            //pause = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {

            Time.timeScale = 1f;
            pause = false;
        }
    }

    public void Resume()
    {
        
        Time.timeScale = 1f;
    }
}
