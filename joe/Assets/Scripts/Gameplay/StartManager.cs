using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public Canvas startCanva;

    void Start()
    {

        Time.timeScale = 0f;
        startCanva.enabled = true;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {

            Time.timeScale = 1f;
            startCanva.enabled = false;
        }
    }
}
