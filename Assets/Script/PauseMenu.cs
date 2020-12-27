using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
    }
    public void PauseGame(){
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
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    
    public void RestartGame(){
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
