using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute_music : MonoBehaviour
{
    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
