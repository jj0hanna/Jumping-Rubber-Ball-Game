using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
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
