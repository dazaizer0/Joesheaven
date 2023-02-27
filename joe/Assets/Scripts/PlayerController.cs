using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    [Header("Movement")]
    public float speed;
    private Rigidbody2D rb;
    public BoxCollider2D boxColider;
    private Vector2 moveDirection;
    private Vector2 movement;

    private bool stoped = false;

    // Shooting
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float FireDelay;

    // Effects
    [Header("Effects")]
    [SerializeField] public AudioSource shooteffect;
    public Animator animator;

    [Header("Shop")]
    public playerStats player;
    private bool speed_bought = false;
    private bool shoot_bought = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColider.enabled = false;
    }

    void Update()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (stoped == true)
        {
            boxColider.enabled = true;
        }
        if (stoped == false)
        {
            boxColider.enabled = false;
        }

        // MOVEMENT
        ProcessInputs();

        // SHOOTING
        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVer = Input.GetAxis("ShootVertical");

        if((shootHor != 0 || shootVer != 0) && Time.time > lastFire + FireDelay)
        {
            Shoot(shootHor, shootVer);
            lastFire = Time.time;
        }

    }

    void Shoot(float x, float y)
    {
        shooteffect.Play();
        PLAYER player = new PLAYER();

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
            );
    }
    void FixedUpdate()
    {
        // MOVEMENT
        Move();

    }

    // MOVEMENT
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "stop")
        {
            GetComponent<BoxCollider2D>();
            stoped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "stop")
        {
            GetComponent<BoxCollider2D>();
            stoped = false;
        }
    }

    public void buy_speed()
    {
        if(speed_bought == false && player.coin >= 3)
        {
            speed += 3;

            speed_bought = true;

            player.coin -= 3;
        }
    }
    public void buy_shoot()
    {
        if(shoot_bought == false && player.coin >= 4)
        {
            FireDelay = 0.19f;
            bulletSpeed = 11f;
            
            shoot_bought = true;

            player.coin -= 4;
        }
    }
}
