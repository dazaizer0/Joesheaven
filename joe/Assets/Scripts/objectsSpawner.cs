using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsSpawner : MonoBehaviour
{
    [Header("Object")]
    public GameObject objectToSpawn;

    [Header("KORDS")]
    public float min_x, min_y, max_x, max_y;
     [Header("STATS")]
    public int howManyObjects;
    void Start()
    {
        for(int i = 0; i < howManyObjects; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y));
            Instantiate(objectToSpawn, randomPos, Quaternion.identity);
        }
    }

    void Update()
    {

    }
}
