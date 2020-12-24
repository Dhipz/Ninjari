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

    public ObjectPooler theObjectPool;

    void Start()
    {
        groundlength = ground.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < pointbatas.position.x)
        {
            distanceground = Random.Range(distancegroundmin, distancegroundmax); //random jarak ground
            transform.position = new Vector3(transform.position.x + groundlength + distanceground, transform.position.y, transform.position.z);

            //Instantiate (ground, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }
    }
}
