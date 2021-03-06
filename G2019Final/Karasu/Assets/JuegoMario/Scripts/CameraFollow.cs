﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private float minPosY;
    public float smoothSpeed = .125f;
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        minPosY = transform.position.y;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        if (transform.position.y < minPosY) transform.position = new Vector3(transform.position.x, minPosY, transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}