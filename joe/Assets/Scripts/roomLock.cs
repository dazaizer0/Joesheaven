using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLock : MonoBehaviour
{
    public Transform room;

    public bool can = true;

    public GameObject dors;

    public GameObject spawner;
    public float spawnerLifeTime;

    void Start()
    {
        dors.SetActive(false);
        //spawner.SetActive(false);
    }

    void Update()
    {
        if(can == false)
        {
            Destroy(dors.gameObject, 16);
            Destroy(spawner.gameObject, spawnerLifeTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && can == true)
        {
            can = false;

            Vector3 SpawnerPosition = new Vector3(room.position.x, room.position.y, room.position.z);
            Instantiate(spawner, SpawnerPosition, Quaternion.identity);

            dors.SetActive(true);
           // spawner.SetActive(true);
        }
    }
}
