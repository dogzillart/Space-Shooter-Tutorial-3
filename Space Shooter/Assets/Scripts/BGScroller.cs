﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float speed;
    public float tileSizeZ;
    private Vector3 startPosition;
    public GameController gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gamecontroller.win == true)
        {
            scrollSpeed += speed * Time.deltaTime;
            if (scrollSpeed <= -30)
            {
                speed = 0f;
                scrollSpeed = -30;
            }
        }
    }
}
