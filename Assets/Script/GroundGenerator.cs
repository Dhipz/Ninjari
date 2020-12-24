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

    //public GameObject[] grounds;
    private int groundselector;
    private float[] groundslength;

    public ObjectPooler[] theObjectPools;

    void Start()
    {
        //groundlength = ground.GetComponent<BoxCollider2D>().size.x;
        groundslength = new float[theObjectPools.Length];

        for(int i=0; i<theObjectPools.Length; i++){
            groundslength[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < pointbatas.position.x)
        {
            distanceground = Random.Range(distancegroundmin, distancegroundmax); //random jarak ground
            
            groundselector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (groundslength[groundselector]/2) + distanceground, transform.position.y, transform.position.z);

            //Instantiate (ground, transform.position, transform.rotation);
            //Instantiate (grounds[groundselector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[groundselector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (groundslength[groundselector]/2), transform.position.y, transform.position.z);

        }
    }
}
