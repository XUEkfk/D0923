using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rd;
    private int count;
    public Text counText;
    public Text winText;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();

    }

    //固定次數更新
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rd.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) ;
        {
            Destroy(other.gameObject);
            count ++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        counText.text = "Count:" + count.ToString();
        if (count>=5)
        {
            winText.text = "You Win"+"  "+"count "+count.ToString();
            counText.text = "";
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
