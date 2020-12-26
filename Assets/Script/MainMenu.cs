using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGames;
    public void PlayGame(){
        SceneManager.LoadScene(playGames);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
