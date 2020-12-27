using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseButton;
    void OnEnable(){
    	pauseButton.SetActive(false);
    }
    public void RestartGame(){
        FindObjectOfType<GameManager>().Reset();
        pauseButton.SetActive(true);
    }
    public void QuitMain(){
        SceneManager.LoadScene(mainMenu);
    }
}
