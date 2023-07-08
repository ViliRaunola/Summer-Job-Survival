using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Pressing paly game button");
        SceneManager.LoadScene("Game");
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
