using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 off;
    private float Y = 0f;
    public float mouseS = 500f;
    
    // Start is called before the first frame update
    void Start()
    {
        off = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("鏡頭旋轉");
        Y += Input.GetAxis("Mouse X")* mouseS * Time.deltaTime;
        //相機鏡頭旋轉
        Quaternion rotation = Quaternion.Euler(0, Y, 0);
        transform.LookAt(player.transform);*/
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + off;
    }
}
