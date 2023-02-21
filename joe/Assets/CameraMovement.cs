using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject camera_;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "camUp")
        {
            camera_.transform.position += Vector3.up * 10f;
        }

        if (other.tag == "camDown")
        {
            camera_.transform.position += Vector3.down * 10f;
        }

        if (other.tag == "camRight")
        {
            camera_.transform.position += Vector3.right * 10f;
        }

        if (other.tag == "camLeft")
        {
            camera_.transform.position += Vector3.left * 10f;
        }
    }
}
