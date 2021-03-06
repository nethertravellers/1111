﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform player;
    private float x;
    private float y;
    private float xSpeed = 400;
    private float ySpeed = 400;
    private float distence;
    private float disSpeed = 100;
    private float minDistence = 1;
    private float maxDistence = 5;

    private Quaternion rotationEuler;
    private Vector3 cameraPosition;
   
    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        y = Mathf.Clamp(y, -90, 90);
        if (x > 360)
        {
            x -= 360;
        }
        else if(x < 0)
        {
            x += 360;
        }

        distence -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
        distence = Mathf.Clamp(distence, minDistence, maxDistence);

        rotationEuler = Quaternion.Euler(y, x, 0);
        cameraPosition = rotationEuler * new Vector3(0, 0, -distence - 2) + player.position;
        //cameraPosition = rotationEuler * new Vector3(0, 0, -4) + player.position;
        transform.rotation = rotationEuler;
        transform.position = cameraPosition;
    }
}
