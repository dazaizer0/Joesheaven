using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{

    [Header("String")]
    private string credits = "Thank you for playing my game, I invite you to places where I am active and I'm probably creating something new right now ;) ";
    private string caption = "Heavenream, all done by Dazai.";
    private string thanks = "Special thanks to: M.G, M.S, R-E-R-E.S, F ";
    private string seeyou = "see you in other productions.";

    [Header("Text")]
    public TextMeshProUGUI credits_txt;
    public TextMeshProUGUI caption_txt;
    public TextMeshProUGUI thanks_txt;
    public TextMeshProUGUI seeyou_txt;

    
    void Start()
    {

        ToTxt(credits_txt, credits);
        ToTxt(caption_txt, caption);
        ToTxt(thanks_txt, thanks);
        ToTxt(seeyou_txt, seeyou);
    }

    public void ToTxt(TextMeshProUGUI text, string str)
    {

        text.text = str;
    }
}
