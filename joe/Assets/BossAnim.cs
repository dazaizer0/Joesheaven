using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    public Canvas bossCanva;

    void Start()
    {

        bossCanva.enabled = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            bossCanva.enabled = true;
            //Time.timeScale = 0f;
            Destroy(bossCanva.gameObject, 1);
        }
    }
}
