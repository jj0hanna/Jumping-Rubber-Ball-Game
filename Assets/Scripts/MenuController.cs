using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    private void Awake()
    {
        AudioManager.PlaySound("MenuMusic");
        AudioManager.StopSound("IngameMusic");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Info()
    {
        SceneManager.LoadScene("MenuInfo");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
