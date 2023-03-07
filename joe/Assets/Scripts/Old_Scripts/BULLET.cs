using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET : MonoBehaviour
{
    public float lifeTime;
    public Collider2D collider2d;
    public GameObject effect;

    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "stop")
        {

            playEffect();

            GetComponent<Collider2D>();
            Destroy(gameObject);
        }

        if (other.tag == "petfrog")
        {

            playEffect();
        }

        if (other.tag == "damage")
        {

            playEffect();
        }
    }

    public void playEffect()
    {

        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
