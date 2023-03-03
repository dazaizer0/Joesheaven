using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FrogHelp : MonoBehaviour
{
    public Canvas frog_help_canvas;
    void Start()
    {
        frog_help_canvas.enabled = false;
        // game made by dazai  Heavenream
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            frog_help_canvas.enabled = true;
            Time.timeScale = 0f;
        }
    }
    public void resume_game()
    {
        frog_help_canvas.enabled = false;
        Time.timeScale = 1f;
    }
}
