using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class playerStats : MonoBehaviour
{

    public Canvas shop;

    [Header("Health")]
    public float healt = 100;
    public TextMeshProUGUI health_text;

    public bool health_bought;

    [Header("Health - checker")]
    public Image damage_true;


    [Header("Score")]
    public float score;
    public TextMeshProUGUI score_text;
    public bool timerActive;

    [Header("Coin")]
    public float coin;
    public TextMeshProUGUI coin_text;

    void Start()
    {

        shop.enabled = false;
        score = PlayerPrefs.GetFloat("act_score");
        damage_true.enabled = false;

        // totext
        totext(score_text, score);
        totext(health_text, healt);
        totext(coin_text, coin);
    }

    void Update()
    {

        if (coin < 0)
        {

            coin = 0;
        }

        //if(healt > 100)
        //{
        //    healt = 100;
        //}

        if(healt < 100)
        {

            healt += 1 * (Time.deltaTime / 3);
        }

        // totext
        totext(score_text, score);
        totext(health_text, healt);
        totext(coin_text, coin);

        if(timerActive)
        {

            score += Time.deltaTime;
            totext(score_text, score);
        }

        // health
        if (healt <= 0)
        {

            healt = 0;

            string aScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(aScene);
            
            PlayerPrefs.DeleteKey("act_float");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "damage")
        {

            healt -= 1;
            totext(health_text, healt);
            damage_taken();
        }

        if (other.tag == "drop")
        {

            coin += 1;
            totext(coin_text, coin);
        }

        if (other.tag == "shoot_damage")
        {

            healt -= 3;
            totext(health_text, healt);
            damage_taken();
        }

        if(other.tag == "heaven")
        {

            PlayerPrefs.SetFloat("act_score", score);
        }

        if (other.tag == "shop")
        {

            shop.enabled = true;
            Time.timeScale = 0f;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "damage")
        {

            damage_true.enabled = false;
        }

        if (other.tag == "shoot_damage")
        {

            damage_true.enabled = false;
        }
    }

    public void totext(TextMeshProUGUI text, float liczba)
    {

        text.text = liczba.ToString("F1");
    }

    public void damage_taken()
    {

        damage_true.enabled = true;
    }

    public void exit_shop()
    {

        shop.enabled = false;
        Time.timeScale = 1f;
    }

    public void buy_health()
    {

        if(health_bought == false && coin >= 3)
        {

            healt += 20;
            coin -= 3;
        }
    }
}
