using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("First");
    }

    public void QuitGame(){
        Application.Quit();
    }
    public void RenewGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
