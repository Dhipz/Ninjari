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

    private float heightgroundmin;
    public Transform heightgroundmaxpoint;
    private float heightgroundmax;
    public float maxheightchange;
    private float heightchange;
    
    private CoinGenerator CG;
    public float randomCoinLimit;

    public float randomSpikeLimit;
    public ObjectPooler spikePool;
    
    void Start()
    {
        //groundlength = ground.GetComponent<BoxCollider2D>().size.x;
        groundslength = new float[theObjectPools.Length];

        for(int i=0; i<theObjectPools.Length; i++){
            groundslength[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        heightgroundmin = transform.position.y;
        heightgroundmax = heightgroundmaxpoint.position.y;

        CG = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()   
    {
        if(transform.position.x < pointbatas.position.x)
        {
            distanceground = Random.Range(distancegroundmin, distancegroundmax); //random jarak ground
            
            groundselector = Random.Range(0, theObjectPools.Length);

            heightchange = transform.position.y + Random.Range(maxheightchange, -maxheightchange); //random height ground

            if(heightchange > heightgroundmax){
                heightchange = heightgroundmax;
            }
            else if(heightchange < heightgroundmin){
                heightchange = heightgroundmin;
            }
            
            transform.position = new Vector3(transform.position.x + (groundslength[groundselector]/2) + distanceground, heightchange, 0);

            

            //Instantiate (ground, transform.position, transform.rotation);
            //Instantiate (grounds[groundselector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[groundselector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if(Random.Range(0f, 100f) < randomCoinLimit){
                CG.SpawnCoins(new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z)); //spawn coin in the ground
            }

            if(Random.Range(0f, 100f) < randomSpikeLimit){
                GameObject newSpike = spikePool.GetPooledObject();
                float spikeXPosition = Random.Range(-groundslength[groundselector]/2 + 1f, groundslength[groundselector]/2);
                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);
                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }
            
            transform.position = new Vector3(transform.position.x + (groundslength[groundselector]/2), transform.position.y, 0);

        }
    }
}
