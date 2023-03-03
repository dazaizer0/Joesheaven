using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioSource musica;
    public bool music = true;
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void QUIT()
    {
        Application.Quit();
        Debug.Log("GAME: -> QUIT");
    }
    public void menumusic()
    {
        Application.OpenURL("https://www.context-sensitive.com/licensing/");

    }
    public void itchio()
    {
        Application.OpenURL("https://havenrim.itch.io/");

    }
    public void yt()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCaVclUbCx-tf50m8N47w59w");

    }
    public void MENU()
    {
        SceneManager.LoadScene(0);
    }
    public void ACH()
    {
        SceneManager.LoadScene(2);
    }
    public void GAME()
    {
        SceneManager.LoadScene(1);
    }
    public void RESTART()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Debug.Log("GAME: -> RESTART");
    }
}
