using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform viewPoint; // 相機視角的參考點
    private Vector3 off;
    private Vector2 mouseInput;//滑鼠輸入值
    private float Y = 0f; //選轉角度
    public float mouseS = 100f; //mouse靈敏度
    private float verticalRotStore; // 垂直旋轉存儲
    
    // Start is called before the first frame update
    void Start()
    {
        off = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // 獲取滑鼠輸入，分別對應 X 和 Y 軸
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseS;
        //相機鏡頭旋轉
        // 累積垂直旋轉並限制範圍，避免翻轉相機
        verticalRotStore -= mouseInput.y;
        verticalRotStore = Mathf.Clamp(verticalRotStore, -60f, 60f); // 限制垂直角度的範圍
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + off;
        // 設置旋轉，根據滑鼠 X 軸旋轉角色，根據滑鼠 Y 軸旋轉視角
        viewPoint.rotation = Quaternion.Euler(verticalRotStore, viewPoint.rotation.eulerAngles.y + mouseInput.x, 0f);
        transform.LookAt(player.transform);
    }
}
