using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ACH_manager : MonoBehaviour
{
    public Image ach1;
    public Image ach2;
    public Image ach3;
    public Image ach4;
    public Image ach5;

    public int a1;
    public int a2;
    public int a3;
    public int a4;
    public int a5;

    public void kasuj()
    {
        PlayerPrefs.DeleteKey("achi1");

        PlayerPrefs.DeleteKey("achi2");

        PlayerPrefs.DeleteKey("achi3");

        PlayerPrefs.DeleteKey("achi4");

        PlayerPrefs.DeleteKey("achi5");
    }
    void Start()
    {
        LOADING_DAVEDATA();
    }

    void Update()
    {
        //Debug.Log("a2: " + PlayerPrefs.GetInt("achi2"));
        if (a1 >= 10)
        {
            ach1.enabled = false;
        }
        if (a2 >= 10)
        {
            ach2.enabled = false;
        }
        if (a3 >= 10)
        {
            ach3.enabled = false;
        }
        if (a4 >= 10)
        {
            ach4.enabled = false;
        }
        if (a5 >= 10)
        {
            ach5.enabled = false;
        }
    }
    public void LOADING_DAVEDATA()
    {
        a1 = PlayerPrefs.GetInt("achi1");
        a2 = PlayerPrefs.GetInt("achi2");
        a3 = PlayerPrefs.GetInt("achi3");
        a4 = PlayerPrefs.GetInt("achi4");
        a5 = PlayerPrefs.GetInt("achi5");
    }
}
