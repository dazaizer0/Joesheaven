using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWNER : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy_f;
    public GameObject enemy_a;
    public GameObject enemy_e;
    public GameObject enemy_frog;
    public GameObject coin;

    public float enemyEInterval = 9f;
    public float enemyFROGInterval = 9f;
    public float enemyFInterval = 9f;
    public float enemyAInterval = 4f;
    public float enemyCOINInterval = 1f;

    void Start()
    {
        StartCoroutine(spawnEnemy(enemyFROGInterval, enemy_frog));
        StartCoroutine(spawnEnemy(enemyEInterval, enemy_e));
        StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
        StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
        StartCoroutine(spawnEnemy(enemyCOINInterval, coin));
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
