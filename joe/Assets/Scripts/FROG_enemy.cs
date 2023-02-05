using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FROG_enemy : MonoBehaviour
{
    public float health;
    float lifeTime;
    public GameObject hpup;

    void Start()
    {
        hpup.GetComponent<Renderer>().enabled = false;

    }

    void Update()
    {
        lifeTime += 1 * Time.deltaTime;
        if(lifeTime >= 39)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            hpup.GetComponent<Renderer>().enabled = true;
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            GetComponent<BoxCollider2D>();
            damage();

        }
    }
    public void damage()
    {
        GetComponent<BoxCollider2D>();
        Debug.Log("dmage have been taken");
        health -= 3;
    }
}
