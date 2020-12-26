using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGames;
    public void PlayGame(){
        Application.LoadLevel(playGames);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
