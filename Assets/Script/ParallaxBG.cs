﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float parallaxFX;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxFX));
        float dist = (cam.transform.position.x * parallaxFX);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if(temp > (startPos + length)){
            startPos += length;
        }
        else if(temp < (startPos - length)){
            startPos -= length;
        }
    }
}
