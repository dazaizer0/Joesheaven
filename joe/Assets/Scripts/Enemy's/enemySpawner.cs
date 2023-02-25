using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float lt;

    public GameObject sp1;
    public GameObject sp2;
    public GameObject sp3;
    public GameObject sp4;
    public GameObject sp5;

    [Header("enemys")]
    [SerializeField]
    public GameObject enemy_f;
    public GameObject enemy_a;


    [Header("interval")]
    public float enemyFInterval;
    public float enemyAInterval;

    public bool start = false;


    void Start()
    {
        //StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
        //StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
    }
    void Update()
    {
        Destroy(gameObject, lt);
        if(start == false)
        {
            StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
            StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
            start = true;

        }else
        {
            Debug.Log("started");
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        int sp = Random.Range(1, 5);

        if(sp == 1)
        {
            Vector3 pos = new Vector3(sp1.transform.position.x, sp1.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        }

        if(sp == 2)
        {
            Vector3 pos = new Vector3(sp2.transform.position.x, sp2.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        }

        if(sp == 3)
        {
            Vector3 pos = new Vector3(sp3.transform.position.x, sp3.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        }

        if(sp == 4)
        {
            Vector3 pos = new Vector3(sp4.transform.position.x, sp4.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        }

        if(sp == 5)
        {
            Vector3 pos = new Vector3(sp5.transform.position.x, sp5.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
// Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0)
//GameObject newEnemy = Instantiate(enemy, new Vector3((Random.Range(this.transform.position.x + 4, this.transform.position.x - 4), (Random.Range(this.transform.position.y + 4, this.transform.position.y - 4))), Quaternion.identity);