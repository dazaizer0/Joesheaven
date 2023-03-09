using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    public GameObject spawnPoint;

    void Start()
    {
        
        Vector3 spawn = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y);
        Instantiate(boss, spawn, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
