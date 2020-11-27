using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// script to handle player high score, displaying score to UI and saving/loading score from binary file.
public class ScoreManager : MonoBehaviour
{
    [Header ("Score Tracker Calibration")]
    public int score;
    public int highScore;
    public int savedhighScore;
    public int allTimeHighScore;
    public string savedPlayerName;
    public Text scoreText;
    public Text highScoreText;
    public Text allTimeHighScoreText;
    private Vector3 startPosition;
    public bool newHighscore = false;
    Rigidbody2D rB;

    private int defaultscore = 1;
    private string defaultname = "Computer";

    //set varaibles and declare components to use
    //load high score and player name
    void Awake()
    {
        startPosition = transform.position;
        highScore = 0;
        newHighscore = false;
        rB = GetComponent<Rigidbody2D>();
        LoadScore();
    }

    void Update()
    {
        // if gameover control bool is not toggled
        // count score, highscore and all time highscore based on distance between player start and current 
        // Y axis, if all time high score is exceeded then save varaible accordinly.
        if (ScreenCollide.gameOver == false)
        {
            score = Mathf.RoundToInt(Mathf.Abs(transform.position.y - startPosition.y));
            highScore = Mathf.Max(score, highScore);
            allTimeHighScore = Mathf.Max(highScore, savedhighScore);
            if (highScore >= savedhighScore)
            {
                newHighscore = true;
            }
        }
        // if game over control bool is toggled, freeze rigidbody to prevent score from changing
        // pass through score varaibles accordinly to UI text for display
        // if new highscore is met, display to player else display previous high score.
        if (ScreenCollide.gameOver == true)
        {
            rB.constraints = RigidbodyConstraints2D.FreezeAll;
            scoreText.text = "Distance Jumped: " + score.ToString();
            highScoreText.text = "Distance Jumped: " + highScore.ToString();
            if (newHighscore == true)
            {
                savedhighScore = allTimeHighScore;
                savedPlayerName = MenuHandler.playerName;
            }
        }
        allTimeHighScoreText.text = "Player " + savedPlayerName + " jumped " + allTimeHighScore.ToString() + " feet";
    }
    //function to reset player for onClick event
    // also saves current score if new all time record was made
    public void OnGameOver()
    {
        rB.constraints = RigidbodyConstraints2D.None;
        transform.position = startPosition;
        ScreenCollide.gameOver = false;  
        if (newHighscore == true)
            {
                SaveScore();
            }
        newHighscore = false;    
    }
    //player UI score tracking and name display
    void OnGUI()
    {
        GUILayout.Label("Current Player: " + MenuHandler.playerName);
        GUILayout.Label("Current Distance Jumped: " + score.ToString() + "  feet");
        GUILayout.Label("Highest Distance This Round: " + highScore.ToString() + "  feet"); 
    }
    //function to save score
    public void SaveScore()
    {
        SaveSystem.SavePlayer(this);
    }
    //function to load score
    public void LoadScore()
    {
        if (System.IO.File.Exists("player.sav"))
        {
            PlayerData data = SaveSystem.LoadPlayer();
            savedPlayerName = data.loadedPlayerName;
            savedhighScore = data.loadedhighScore;
        }
        else
        {
            savedPlayerName = defaultname;
            savedhighScore = defaultscore;
        }

    }

}
