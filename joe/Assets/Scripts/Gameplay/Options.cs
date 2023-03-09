using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Canvas options;


    void Start()
    {
        options.enabled = false;

        if(!PlayerPrefs.HasKey("music_volume"))
        {

            PlayerPrefs.SetFloat("music_volume", 1);
            Load();
        }else{

            Load();
        }
    }

    void Update()
    {
        
    }

    public void FullScreen()
    {

        Screen.fullScreen = !Screen.fullScreen;
        print("screen setting changed");
    }

    public void ChangeVolume()
    {

        AudioListener.volume = volumeSlider.value;
    }

    // save
    private void Load()
    {

        volumeSlider.value = PlayerPrefs.GetFloat("music_volume");
    }
    
    public void Save()
    {

        PlayerPrefs.SetFloat("music_volume", volumeSlider.value);
    }

    public void OptionsOn()
    {
        options.enabled = true;
    }
    public void OptionsOff()
    {
        options.enabled = false;
    }
}
