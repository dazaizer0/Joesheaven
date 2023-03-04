using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_scr : MonoBehaviour
{
    float lifeTime;

    void Start()
    {
        
    }

    void Update()
    {
        lifeTime += 1 * Time.deltaTime;
        if (lifeTime >= 9)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
