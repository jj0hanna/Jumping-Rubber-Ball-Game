using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
     public void RestartGame()
     {
         SceneManager.LoadScene("SampleScene");
     }

     public void Quit()
     {
         SceneManager.LoadScene("Menu");
     }
}
