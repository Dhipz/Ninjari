using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform groundGenerator;
    private Vector3 groundStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private GroundDestroyer[] groundList;
    private ScoreManager SM;

    public DeathMenu deathScreen;

    private AudioSource playSound;

    // Start is called before the first frame update
    void Start()
    {
        groundStartPoint = groundGenerator.position;
        playerStartPoint = player.transform.position;
        SM = FindObjectOfType<ScoreManager>();
        playSound = GameObject.Find("playsfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void RestartGame(){
        //StartCoroutine("RestartGameCo");
        SM.scoreIncrease = false;
        player.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
        playSound.Pause();
    }
    public void Reset(){
        playSound.Play();
        deathScreen.gameObject.SetActive(false);
        groundList = FindObjectsOfType<GroundDestroyer>();
        for(int i=0; i<groundList.Length; i++){
            groundList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        groundGenerator.position = groundStartPoint;
        player.gameObject.SetActive(true);
        SM.scoreCounter = 0;
        SM.scoreIncrease = true;
    }
    /* public IEnumerator RestartGameCo(){
        SM.scoreIncrease = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        groundList = FindObjectsOfType<GroundDestroyer>();
        for(int i=0; i<groundList.Length; i++){
            groundList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        groundGenerator.position = groundStartPoint;
        player.gameObject.SetActive(true);
        SM.scoreCounter = 0;
        SM.scoreIncrease = true;
    }*/
}
