using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public GameObject rulesWindow;

    public string playGames;
    public void PlayGame(){
        SceneManager.LoadScene(playGames);
    }

    public void RulesGame(){
        rulesWindow.SetActive(true);
    }

    public void QuitRulesGame(){
        rulesWindow.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
