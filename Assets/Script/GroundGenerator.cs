using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject ground;
    public Transform pointbatas;
    public float distanceground;

    private float groundlength;

    public float distancegroundmin;
    public float distancegroundmax;

    public GameObject[] grounds;
    private int groundselector;
    private float[] groundslength;

    //public ObjectPooler theObjectPool;

    void Start()
    {
        //groundlength = ground.GetComponent<BoxCollider2D>().size.x;
        groundslength = new float[grounds.Length];

        for(int i=0; i<grounds.Length; i++){
            groundslength[i] = grounds[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < pointbatas.position.x)
        {
            distanceground = Random.Range(distancegroundmin, distancegroundmax); //random jarak ground
            
            groundselector = Random.Range(0, grounds.Length);

            transform.position = new Vector3(transform.position.x + groundslength[groundselector] + distanceground, transform.position.y, transform.position.z);

            //Instantiate (ground, transform.position, transform.rotation);
            Instantiate (grounds[groundselector], transform.position, transform.rotation);
            //GameObject newPlatform = theObjectPool.GetPooledObject();

            //newPlatform.transform.position = transform.position;
            //newPlatform.transform.rotation = transform.rotation;
            //newPlatform.SetActive(true);

        }
    }
}
