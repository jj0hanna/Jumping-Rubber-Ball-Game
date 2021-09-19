using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public Text uiStars;
    
    public static int stars;

    private int distance;
    private int score;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlaySound("IngameMusic");
        AudioManager.StopSound("MenuMusic");
        player = GameObject.Find("Player");
        gameOver = false;
        stars = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            
            // calculate where the player is at the start and keep track of the meters the player is moving
            distance = Mathf.RoundToInt(player.transform.position.x + 14); 
            uiDistance.text = distance.ToString() + " M";
            
            time += 1 * Time.deltaTime; // timer
            uiTime.text = "Time: " + ((int) time).ToString() ;

            uiStars.text = "Stars: " + stars.ToString();
            
            Time.timeScale = 1;
            
        }

        if (gameOver)
        {
            GameOverPanel.SetActive(true);
            score = distance / ((int) time) + stars; // calculate the score
            uiScore.text = "Score: " + score.ToString();
            
            if (score <= 0)
            {
                score = 0;
            }
            Time.timeScale = 0;
        }
    }
}
