using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PAUSE_MENU : MonoBehaviour
{
    public Canvas menu;
    public bool menuActivated;

    void Start()
    {
        menu.enabled = false;
        menuActivated = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 0;
            menu.enabled = true;
            menuActivated = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        /*if (Input.GetKeyDown(KeyCode.Escape) && menuActivated == true)
        {
            menu.enabled = false;
            menuActivated = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }*/
    }
    public void resume()
    {
        menu.enabled = false;
        menuActivated = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
