using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("enemys")]
    [SerializeField]
    public GameObject enemy_f;
    public GameObject enemy_a;
    public GameObject enemy_e;
    public GameObject enemy_frog;


    [Header("interval")]
    public float enemyEInterval;
    public float enemyFROGInterval;
    public float enemyFInterval;
    public float enemyAInterval;


    void Start()
    {
        StartCoroutine(spawnEnemy(enemyFROGInterval, enemy_frog));
        StartCoroutine(spawnEnemy(enemyEInterval, enemy_e));
        StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
        StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
    }

    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-24f, 24), Random.Range(-12f, 12f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
