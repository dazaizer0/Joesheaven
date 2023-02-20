using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLock : MonoBehaviour
{
    public Transform room;
    public bool can = true;
    public GameObject dors;
    public GameObject spawner;

    void Start()
    {
        dors.SetActive(false);
        spawner.SetActive(false);
    }

    void Update()
    {
        if(can == false)
        {
            Destroy(dors.gameObject, 16);
            Destroy(spawner.gameObject, 13);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && can == true)
        {
            can = false;

            dors.SetActive(true);
            spawner.SetActive(true);

            /*for(int i = 0; i < 5; i++)
            {
                Vector3 pos = new Vector3(room.position.x, room.position.y);
                Instantiate(enemy, pos, Quaternion.identity);
            }*/
        }
    }
}
