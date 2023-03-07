using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    public roomLock currentRoom;
    public float speed;

    void Awake()
    {

        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

        UpdatePosition();
    }

    void UpdatePosition()
    {

        if(currentRoom == null)
        {

            return;
        }
    }
}
