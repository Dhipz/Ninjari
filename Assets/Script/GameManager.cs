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
    // Start is called before the first frame update
    void Start()
    {
        groundStartPoint = groundGenerator.position;
        playerStartPoint = player.transform.position;
        SM = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void RestartGame(){
        StartCoroutine("RestartGameCo");
    }
     public IEnumerator RestartGameCo(){
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
    }
}
