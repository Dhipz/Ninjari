using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public float scoreCounter;
    public float highScoreCounter;
    public float pointPerSecond;
    public bool scoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore")){
            highScoreCounter = PlayerPrefs.GetFloat("HighScore");
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if(scoreIncrease){
            scoreCounter += pointPerSecond * Time.deltaTime;
        }
        
        if(scoreCounter > highScoreCounter){
            highScoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("HighScore", highScoreCounter);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCounter);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCounter);
    }
}
