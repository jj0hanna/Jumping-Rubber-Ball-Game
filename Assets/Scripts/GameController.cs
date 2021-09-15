using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject GameOverPanel;
    public static bool gameOver;
    public Text uiDistance;
    public Text uiTime;
    public Text uiScore;

    private int distance;
    private int score;
    private float time;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            // calculate where the player is at the start and keep track of the meters the player is moving
            distance = Mathf.RoundToInt(player.transform.position.x + 11); 
            uiDistance.text = distance.ToString() + " M";
           
            time += 1 * Time.deltaTime; // timer
            uiTime.text = "Time: " + ((int) time).ToString() ;
        }

        if (gameOver)
        {
            Time.timeScale = 1;
            GameOverPanel.SetActive(true);
            
            score = distance / ((int) time); // calculate the score
            uiScore.text = "Score: " + score.ToString();
            if (score <= 0)
            {
                score = 0;
            }
        }

        
    }
}
