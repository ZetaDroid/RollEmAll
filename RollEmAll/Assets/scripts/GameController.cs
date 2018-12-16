using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private int totalDiamonds;
    public int diamondsCollected;//PRIVATE
    Text diamondsCollectedText;     
    public Transform levelFinish;
    



    void Start()
    {
        totalDiamonds = 10;
        diamondsCollected = 0;
        diamondsCollectedText = levelFinish.Find("DiamondCount/Image/DiamondsCollected").GetComponent<Text>();
    }
    public void CountDiamonds()
    {
        diamondsCollected++;
        diamondsCollectedText.text = "" + diamondsCollected;
    }
    void Update()
    {
        
        if (diamondsCollected >= totalDiamonds)
        {
            LevelPassed();
        }
        
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("levelChooser", LoadSceneMode.Single);
        }
    }
    void LevelPassed()
    {
        //Admanager.CheckForAd();
        levelFinish.GetComponent<LevelFinish>().LevelFinished();
        diamondsCollected = 0;
        
    }
    
}
