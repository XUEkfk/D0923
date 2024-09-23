using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // 玩家角色
    public Transform viewPoint; // 相機視角的參考點
    private Vector3 off; // 初始偏移量
    private Vector2 mouseInput; // 滑鼠輸入
    public float mouseS = 1f; // 滑鼠靈敏度
    private float verticalRotStore = 0f; // 垂直旋轉累積
    private float Y = 0f; // 水平旋轉累積
    
    // Start is called before the first frame update
    void Start()
    {
        // 鎖定滑鼠指標
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // 計算初始的相機偏移量
        off = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 獲取滑鼠輸入
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseS;

        // 累積垂直旋轉，並限制範圍，避免翻轉
        verticalRotStore -= mouseInput.y;
        verticalRotStore = Mathf.Clamp(verticalRotStore, -60f, 60f); // 限制垂直角度

        // 累積水平旋轉
        Y += mouseInput.x;
    }

    void LateUpdate()
    {
        // 根據玩家的位置更新相機位置
        Quaternion rotation = Quaternion.Euler(verticalRotStore, Y, 0f);
        transform.position = player.transform.position + rotation * off;

        // 保持相機面向玩家
        transform.LookAt(player.transform.position);
    }
}