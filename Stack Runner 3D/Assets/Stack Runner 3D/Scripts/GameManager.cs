using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;          

    public Text scoreText,levelText, levelScoreText;               

    public int score, levelScore, totalLevelScore;    

    public bool isLevelFinish,isSwipeToStart;

    public GameObject gameoverScreen, gameStartScreen, gameNextLevelScreen;

    public PlayerController playerController;

    public LevelController levelController;

    public GameObject player;

    public Button gameNextLevelButton;

    private void Awake()
    {
        instance = this;
        StopGame();                 // stop the game 
        gameoverScreen.SetActive(false);            // desactive the game over screen
        gameNextLevelScreen.SetActive(false);         // desactive the next level screen
        playerController.AddBoatStart();              // add the boat when start the game
        playerController.conffeti.gameObject.SetActive(false);    // desactive the particle systeme
    }

    void Start()
    {
        SaveGameGet();    // get the saving game

    }

    void Update()
    {  
        SaveGameSet();           
        levelScoreText.text = "Coins:"+totalLevelScore.ToString();     //convert the level score text to string
        SwipeToStart();     // call the Swip method
    }

    private void SwipeToStart()     // swip method to control the player
    {
        if (!isSwipeToStart && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            StartGame();
        }
        else if (!isSwipeToStart && Input.GetMouseButton(0))
        {
            StartGame();
        }

        isSwipeToStart = true;
    }

    public void AddPoint(int point)      
    {
        score += point;     // add score
        levelScore += point; // add level points
    }

    public void StartGame()        // start game method
    {
        Time.timeScale = 1.0f;
        gameStartScreen.SetActive(false);   // actibe the start screen 
    }

    public void LoseGame()      // lose game method
    {
        
        
            
            gameoverScreen.SetActive(true); // active the game over screen
            StopGame();
      
              

    }

    public void StopGame()      // stop game method
    {
        Time.timeScale = 0.0f;
    }

    public void RestartGame()     // restart game button
    {
        
        gameoverScreen.SetActive(false);   // desactive game over screen
        levelController.RestartGame();           
        playerController.DestroyBoats();
        playerController.PlayerStartPosition(); // set the player to the first position
        StopGame();
        gameStartScreen.SetActive(true);
        levelScore = 0;

    }

    public void NextLevel() //Next level Button
    {

        StartCoroutine(NextLevelMethod());
        playerController.conffeti.gameObject.SetActive(false);     //desactive particleSysteme

    }

    IEnumerator NextLevelMethod()            // next level method
    {
        gameNextLevelButton.interactable = false;       // desactive next level button
        score = score + totalLevelScore;                // add the score
        yield return new WaitForSecondsRealtime(2);
        levelController.levelCount++;                  // increase the level by 1
        gameNextLevelScreen.SetActive(false);          // desactive the next level screen
        levelController.NextLevel();
        playerController.DestroyBoats();            // destroy the boat 
        playerController.PlayerStartPosition();    // set the player position
        gameStartScreen.SetActive(true);           // active the start screen
        StopGame();                      
        RandomLevel();                              // generate random level
        levelScore = 0;                             // set the level score to 0
        isSwipeToStart = false;                         // set to the false
        playerController.PlayerControlActiveTrue();
        gameNextLevelButton.interactable = true;
    }

    public void FinishLevel() // Finish Level 
    {
        if (isLevelFinish)
        {
            playerController.PlayerControlActiveFalse();
            playerController.WinAnimation();
         
            StartCoroutine(StartFinishMethod());
            
        }      
        

    }

    IEnumerator StartFinishMethod()
    {
        yield return new WaitForSecondsRealtime(4);
        gameNextLevelScreen.SetActive(true);           // active the next level screen
        StopGame();
    }

    private void SaveGameGet()           // when get save game
    {
        //PlayerPrefs.DeleteAll();

        score = PlayerPrefs.GetInt("score");                                  // get the save score
        levelController.levelCount = PlayerPrefs.GetInt("level");             // get the save level
        levelController.randomLevel = PlayerPrefs.GetInt("randomlevel");      // get the save random level
    }

    private void SaveGameSet()               // when set the save game
    {
        PlayerPrefs.SetInt("randomlevel", levelController.randomLevel);      //save randomlLevel

        PlayerPrefs.SetInt("level", levelController.levelCount);             //save levels
        levelText.text = "Level " + (levelController.levelCount + 1).ToString(); //  increase level by 1 and convert to string

        PlayerPrefs.SetInt("score", score);                      // save the score
        scoreText.text = "$ " + score.ToString();           //   convert scor text to string
    }

    private void RandomLevel()         // generate random level
    {
        levelController.randomLevel = UnityEngine.Random.Range(0, levelController.prefabLevels.Count);
    }

    public void LevelTotalPoint(int xpoint)       // total point add to score when the player win the game
    {

        totalLevelScore = levelScore * xpoint *7;
  
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
