using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseButton;

    private AudioSource playSound;

    void Start(){
        playSound = GameObject.Find("playsfx").GetComponent<AudioSource>();
    }

    void OnEnable(){
    	pauseButton.SetActive(false);
    }
    public void RestartGame(){
        playSound.Play();
        FindObjectOfType<GameManager>().Reset();
        pauseButton.SetActive(true);
    }
    public void QuitMain(){
        SceneManager.LoadScene(mainMenu);
    }
}
