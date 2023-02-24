using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCameraMove : MonoBehaviour
{
    [Header("Direction.bool")]
    public bool changed = false;

    [Header("GameObjects")]
    public GameObject positive;
    public GameObject negative;

    void Start()
    {
        
    }

    void Update()
    {
        if(changed == false){
            positive.SetActive(true);
            negative.SetActive(false);
        }
        else if(changed == true){
            positive.SetActive(false);
            negative.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(changed == false){
                changed = true;
            }

            if(changed == true){
                changed = false;
            }
        }
    }
}
