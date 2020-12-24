using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    public GameObject batasgrounddestroy;

    // Start is called before the first frame update
    void Start()
    {
        batasgrounddestroy = GameObject.Find("BatasGroundDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < batasgrounddestroy.transform.position.x)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
