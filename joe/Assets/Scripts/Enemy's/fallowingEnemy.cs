using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallowingEnemy : MonoBehaviour
{

    public float health;
    public BoxCollider2D bc2d;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public GameObject effect;

    public float geting_damage;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        if (health <= 0)
        {

            Vector3 effectPos = new Vector3(transform.position.y, transform.position.y);
            Instantiate(effect, effectPos, Quaternion.identity);

            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if ((Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance))
        {

            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "bullet")
        {

            GetComponent<BoxCollider2D>();
            damage();

        }

        if (other.tag == "petfrog")
        {

            GetComponent<BoxCollider2D>();
            damage();
        }
    }

    public void damage()
    {

        GetComponent<BoxCollider2D>();
        Debug.Log("dmage have been taken");
        health -= geting_damage;
    }
}
