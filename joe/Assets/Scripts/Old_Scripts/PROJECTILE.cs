 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROJECTILE : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    private Transform player;
    private Vector2 target;
    public GameObject effect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

   /* IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }*/

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("petfrog"))
        {
            DestroyProjectile();
        }
        //if (other.CompareTag("stop"))
        //{
        //    DestroyProjectile();
        //}
    }
    void DestroyProjectile()
    {
        playEffect();
        Destroy(gameObject);
    }
    public void playEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
