using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;
    
    public void RestartGame(){
        FindObjectOfType<GameManager>().Reset();
    }
    public void QuitMain(){
        SceneManager.LoadScene(mainMenu);
    }
}
