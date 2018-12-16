using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCon2 : MonoBehaviour
{
    public bool allCollected;

    public Text dCollectedText;

    private int totalDiamonds;
    private int diamondsCollected;



    void Start()
    {
        totalDiamonds = 10;
        diamondsCollected = 0;
    }
    public void CountDiamonds()
    {
        diamondsCollected++;
        dCollectedText.text = "" + diamondsCollected;
    }
    void Update()
    {
        //Debug.Log("Diamonds " + diamondsCollected);
        if (diamondsCollected >= totalDiamonds)
        {
            LevelPassed();
            //OpenExit();//or
            //FinishLevel();
        }
        //TODO Test code. Delete This later
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadSceneAsync("levelChooser", LoadSceneMode.Single);
        }
    }
    void LevelPassed()
    {
        Admanager.CheckForAd();
        allCollected = true;
    }

}
