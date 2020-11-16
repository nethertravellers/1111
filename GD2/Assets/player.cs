using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float RotateSpeed = 1;
    public float rotSpeed = 50;

    //private Vector3 moveX;
    private float currentV;
    private float currentH;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //moveX = transform.right * h;
        
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * 10);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * 10);
        //currentH = Mathf.Lerp(currentH, h, 10);

        transform.position += transform.forward * currentV * Time.deltaTime * MoveSpeed;
        //transform.position += (moveX + moveZ) * Time.deltaTime * MoveSpeed;
        transform.rotation *= Quaternion.Euler(new Vector3(0, currentH * Time.deltaTime * rotSpeed, 0));
        //transform.rotation *= Quaternion.Euler(new Vector3(0, currentH * rotSpeed, 0));
        //transform.localRotation *= Quaternion.Euler(new Vector3(0, currentH * rotSpeed, 0));

    }
  
}

