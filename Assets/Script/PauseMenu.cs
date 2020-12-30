using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    private AudioSource playSound;

    void Start(){
        playSound = GameObject.Find("playsfx").GetComponent<AudioSource>();
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
    }
    public void PauseGame(){
        playSound.Pause();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);

        /*while(true){
            if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.P)){
                ResumeGame();
            }
        }*/
    }
    public void ResumeGame(){
        playSound.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    
    public void RestartGame(){
        playSound.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        FindObjectOfType<GameManager>().Reset();
    }
    public void QuitMain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
