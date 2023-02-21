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
    public Transform room;

    void Start()
    {
        this.transform.SetParent(room.transform);


        StartCoroutine(spawnEnemy(enemyAInterval, enemy_a));
        StartCoroutine(spawnEnemy(enemyFInterval, enemy_f));
    }
    void Update()
    {
        Destroy(gameObject, 13);
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

        GameObject newEnemy = Instantiate(enemy, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
// Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0)
//GameObject newEnemy = Instantiate(enemy, new Vector3((Random.Range(this.transform.position.x + 4, this.transform.position.x - 4), (Random.Range(this.transform.position.y + 4, this.transform.position.y - 4))), Quaternion.identity);