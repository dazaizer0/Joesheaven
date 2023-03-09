using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsSpawner : MonoBehaviour
{
    [Header("Object")]
    public GameObject objectToSpawn;
    public GameObject room;

    //[Header("KORDS")]
    //public float min_x, min_y, max_x, max_y;
     [Header("STATS")]
    public int howManyObjects;

    void Start()
    {

        for(int i = 0; i < howManyObjects; i++)
        {

            Vector3 randomPos = new Vector3(Random.Range(room.transform.position.x - 3.5f, room.transform.position.x + 3.5f), Random.Range(room.transform.position.y - 3.5f, room.transform.position.y + 3.5f));
            Instantiate(objectToSpawn, randomPos, Quaternion.identity);
        }
    }
}
