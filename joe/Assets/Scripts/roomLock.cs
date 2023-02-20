using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLock : MonoBehaviour
{
    public Transform room;
    public GameObject enemy;
    public bool can = true;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && can == true)
        {
            can = false;
            for(int i = 0; i < 2; i++){
                Vector3 pos = new Vector3(room.position.x, room.position.y);
                Instantiate(enemy, pos, Quaternion.identity);
            }
        }
    }
}
