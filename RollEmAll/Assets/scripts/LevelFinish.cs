using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public Transform player;
    public Text levelFinishText;
    public Text timeTakenText,timeRecordText;
    public int stars = 3;
    public audioManagement am;

    //Keep These Private
    public float[] allRecordTime = new float[37];
    public int[] allRecordStar = new int[37];
    int recordScore;



    // int starRecord;//Record from filestream;
    // public LevelscoreManager levelScoreManager;

    private string levelFinishString =  "LEVEL COMPLETED!";
    int sceneBuildIndex;
    
    
    bool levelPassed=false;
    public bool levelFailed = false;//in use by other
    private float timeRecord;//record time from FileStream.
    Animator anim;
    void Awake()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        anim = GetComponent<Animator>();
        //    timeRecord = LevelscoreManager.recordTimeArray[SceneManager.GetActiveScene().buildIndex];
        allRecordTime = LevelscoreManager.LoadRecordTime();//HERE IS FILESTREAM
        allRecordStar = LevelscoreManager.LoadRecordStar();//HERE IS FILESTREAM
        recordScore = LevelscoreManager.LoadRecordScore();
        timeRecord = allRecordTime[sceneBuildIndex];
        levelFinishText.text = LevelFinishTextManager.RandLevelFailedText();
    }

    void Update()
    {
        if (levelPassed)
        {
            anim.SetBool("LevelPassed", true);
            levelFinishText.text = levelFinishString;
        }
        if (!levelPassed && player.position.y < -4)
        {
            anim.SetBool("LevelFailed", true);
            am.PlayLevelFailed();

        }
        if (player.position.y < -4)
        {
            if (!levelFailed)
            {
                Admanager.CheckForAd();
            }
            levelFailed = true;
            
        }
    }
    public void LevelFinished()
    {
        am.PlayLevelPassed();
        levelPassed = true;
        float timeCurrent;
        timeCurrent = Time.timeSinceLevelLoad;
        if (timeRecord==0 || timeRecord > timeCurrent)
        {
            timeRecord = timeCurrent;
            levelFinishString = LevelFinishTextManager.RandLevelPassedText();
            allRecordStar[sceneBuildIndex] = stars;
            allRecordTime[sceneBuildIndex] = timeRecord;
            LevelscoreManager.SavePlayer(allRecordStar,allRecordTime,recordScore);
        }
        timeTakenText.text = timeCurrent + " sec";
        timeRecordText.text = timeRecord + " sec";
        Admanager.CheckForAd();
    }
    

}
