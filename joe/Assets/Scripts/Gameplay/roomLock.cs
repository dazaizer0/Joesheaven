using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLock : MonoBehaviour
{
    public float room_time;

    public Transform room;

    public bool can = true;

    public GameObject dors;

    public GameObject spawner;
    public GameObject drop;
    public float spawnerLifeTime;

    bool end = false;
    private bool allowToDestroy = true;

    public float i = 0;

    void Start()
    {

        dors.SetActive(false);
    }

    void Update()
    {

        if(can == false && end == false)
        {

            i += 1 * Time.deltaTime;

            if(i >= room_time)
            {

                dors.SetActive(false);
                Vector3 SpawnerPosition = new Vector3(room.position.x, room.position.y, room.position.z);
                Instantiate(drop, SpawnerPosition, Quaternion.identity);
                i = 0;

                end = true;
            }

            //Destroy(dors.gameObject, 16);
            //Destroy(spawner.gameObject, spawnerLifeTime);
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
        }
    }
}
