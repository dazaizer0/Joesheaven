using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
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
        StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
        StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
    }
    void Update()
    {
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
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
