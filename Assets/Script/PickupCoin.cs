using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    public int scoreGive;
    private ScoreManager ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            ScoreManager.AddScore(scoreGive); //add coin to score
            gameObject.SetActive(false);
        }
    }
}
