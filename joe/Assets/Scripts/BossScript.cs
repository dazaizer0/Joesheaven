using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject spanwer;
    public GameObject heaven;

    public GameObject stop;

    bool start = false;
    public float i = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Boss_start();
        }

    }

    void Start()
    {
        spanwer.SetActive(false);
        heaven.SetActive(false);
    }

    void Update()
    {
        if(start == true)
        {
            i += 1 * Time.deltaTime;
        }

        if(i >= 17)
        {
            heaven.SetActive(true);
        }
    }

    public void Boss_start()
    {
        spanwer.SetActive(true);
        start = true;
    }
}
