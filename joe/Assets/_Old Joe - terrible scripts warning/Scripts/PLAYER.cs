using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 orignalCameraPos;

    // Shake Parameters
    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;

    private bool canShake = false;
    private float _shakeTimer;
    //-------------------
    public Canvas END;
    public GameObject StopDorsToHeaven;
    [SerializeField] public AudioSource shooteffect;

    //-------------
    public int ach1;
    public int ach2;
    private int ach3;
    private int ach4;
    private int ach5;
    //-------------
    public Canvas shop_panel;

    public int coins;
    public Text Coins;

    public Text FinslScore;

    public Text Score;
    public float score;

    public Canvas dead_panel;
    public Canvas ui_panel;

    public Animator animator;
    public bool stoped = false;
    public GameObject Player;
    // MOVEMENT
    public float speed;
    public Rigidbody2D rb;
    public BoxCollider2D bc2d;
    private Vector2 moveDirection;
    private Vector2 movement;

    // STATS
    public float maxhealth;
    public float health;
    public Text HealthText;

    // SHOOTING
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private float lastFire;
    public float FireDelay;

    void Start()
    {
        orignalCameraPos = cameraTransform.localPosition;
        END.enabled = false;
        /*if (_sound == null)
        {
            Debug.Log("You haven't specified _sound through the inspector");
            this.enabled = false; //disables this script cause there is no sound loaded to play
        }

        audio = gameObject.AddComponent<AudioSource>(); //adds an AudioSource to the game object this script is attached to
        audio.playOnAwake = false;
        audio.clip = _sound;
        audio.Stop();*/


        ach1 = 0; ach2 = 0; ach3 = 0; ach4 = 0; ach5 = 0;

        shop_panel.enabled = false;
        bc2d.enabled = false;
        HealthText.text = health.ToString();
        health = 100;
        maxhealth = 100;

        ui_panel.enabled = true;
        dead_panel.enabled = false;
    }

    void Update()
    {
        if(speedbought == true && bulletspeedbought  == true && cooldownbought == true && healthbought == true)
        {
            ach4 = 10;
        }
        if (score > 100)
        {
            ach3 = 10;
        }

        if(score >= 277)
        {
            StopDorsToHeaven.SetActive(false);
        }
        if (score <= 277){
            StopDorsToHeaven.SetActive(true);
        }

        Coins.text = coins.ToString();

        score += 1 * Time.deltaTime;
        Score.text = score.ToString();
        FinslScore.text = score.ToString();

        HealthText.text = health.ToString();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (stoped == true)
        {
            bc2d.enabled = true;
        }
        if (stoped == false)
        {
            bc2d.enabled = false;
        }
        // health
        if (health <= 0)
        {
            health = 0;
            ui_panel.enabled = false;
            dead_panel.enabled = true;
            Time.timeScale = 0f;

            SAVEING();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (health >= maxhealth)
        {
            health = maxhealth;
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
        if (other.tag == "damage")
        {
            GetComponent<BoxCollider2D>();
            health -= 3;

        }
        if (other.tag == "shoot_damage")
        {
            GetComponent<BoxCollider2D>();
            health -= 7;
            ShakeCamera();
            if (canShake)
            {
                StartCameraShakeEffect();
            }

        }
        if (other.tag == "frog")
        {
            GetComponent<BoxCollider2D>();
            ach1 = 10;

        }
        if (other.tag == "cry")
        {
            GetComponent<BoxCollider2D>();
            health -= 13;

        }
        if (other.tag == "hpup")
        {
            GetComponent<BoxCollider2D>();
            health += 70;
            coins += 20;

        }
        if (other.tag == "shop")
        {
            shop_panel.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ach2 = 10;
            PlayerPrefs.SetInt("achi2", ach2);
            Debug.Log("zapisano ach2: " + PlayerPrefs.GetInt("achi2"));
            
            Time.timeScale = 0f;


        }

        if (other.tag == "COIN_F")
        {
            coins += 50;
        }
        if (other.tag == "COIN_e")
        {
            coins += 10;
        }
        if (other.tag == "COIN_A")
        {
            coins += 40;

        }
        if (other.tag == "heaven")
        {
            ach5 = 10;
            SAVEING();
            END.enabled = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
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
    public void quitshop()
    {
        shop_panel.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    // SHOP VOIDS

    public bool speedbought = false;
    public bool healthbought = false;
    public bool bulletspeedbought = false;
    public bool cooldownbought = false;

    public void buyspeed()
    {
        if((coins >= 80) && (speedbought == false))
        {
            speed += 2;

            coins  = coins - 80;
            Coins.text = coins.ToString();

            speedbought = true;
}
        else
        {
            Debug.Log("NONE_buy1");
        }
    }

    public void buyhealth()
    {
        if ((coins >= 90) && (healthbought == false))
        {
            maxhealth = 150;
            health = maxhealth;

            coins = coins - 90;
            Coins.text = coins.ToString();

            healthbought = true;
        }
        else
        {
            Debug.Log("NONE_buy2");
        }
    }

    public void buybulletspeed()
    {
        if ((coins >= 60) && (bulletspeedbought == false))
        {
            bulletSpeed += 2;

            coins = coins - 60;
            Coins.text = coins.ToString();

            bulletspeedbought = true;
        }
        else
        {
            Debug.Log("NONE_buy3");
        }
    }
    public void buycooldown()
    {
        if ((coins >= 99) && (cooldownbought == false))
        {
            FireDelay -= 0.1f;

            coins = coins - 99;
            Coins.text = coins.ToString();

            cooldownbought = true;
        }
        else
        {
            Debug.Log("NONE_buy4");
        }
    }
    public void SAVEING()
    {
        PlayerPrefs.SetInt("achi1", ach1);

        PlayerPrefs.SetInt("achi2", ach2);
        Debug.Log("zapisano ach2: " + PlayerPrefs.GetInt("achi2"));
        PlayerPrefs.SetInt("achi3", ach3);

        PlayerPrefs.SetInt("achi4", ach4);

        PlayerPrefs.SetInt("achi5", ach5);
    }
    public void ShakeCamera()
    {
        canShake = true;
        _shakeTimer = shakeDuration;
    }

    public void StartCameraShakeEffect()
    {
        if (_shakeTimer > 0)
        {
            cameraTransform.localPosition = orignalCameraPos + Random.insideUnitSphere * shakeAmount;
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;
            cameraTransform.position = orignalCameraPos;
            canShake = false;
        }
    }
}