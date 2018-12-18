using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessGameCon : MonoBehaviour
{
    public Text scoreText,bestScoreText,gameOvertext;
    public int score;
    public Transform player;
    public Animator uiAnim;

    //Data From FileStream;
    public float[] allRecordTime = new float[37];
    public int[] allRecordStar = new int[37];
    public int recordScore;

    private bool isGameOver;


    void Start()
    {
        allRecordTime = LevelscoreManager.LoadRecordTime();//HERE IS FILESTREAM
        allRecordStar = LevelscoreManager.LoadRecordStar();//HERE IS FILESTREAM
        recordScore = LevelscoreManager.LoadRecordScore();//& HERE

        bestScoreText.text = "Best : " + recordScore;
        isGameOver = false;
    }
    
    void Update()
    {
        scoreText.text = "Score : " + score;
        if(!isGameOver)
        {
            if (player.position.y < -3)
        {
            GameOver();
        }
        }
    }
    public void AddScore()
    {
        score+=10;//TEST
    }
    void GameOver()
    {
        isGameOver = true;
        uiAnim.SetTrigger("GameOver");
        Admanager.CheckForAd();
        if (score > recordScore)
        {
            gameOvertext.text = "NEW RECORD!";
            bestScoreText.text = "Best : " + score;
            recordScore = score;
            LevelscoreManager.SavePlayer(allRecordStar, allRecordTime, recordScore);
        }
    }
   
}
