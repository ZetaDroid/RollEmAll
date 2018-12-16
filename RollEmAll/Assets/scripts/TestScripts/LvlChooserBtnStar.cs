using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlChooserBtnStar : MonoBehaviour
{

    public int levelIndex;
    public int starGainedInLevel;
    public int[] allRecStar;

    public int starCount;

    public GameObject lockerImg;
    public int minimumStrToAllowLvl;
    public Image[] starsImageArray = new Image[3];
    void Awake()
    {
        allRecStar = LevelscoreManager.LoadRecordStar();
        starGainedInLevel = allRecStar[levelIndex];
        lockerImg = transform.Find("LockFilter").gameObject;
        if(starGainedInLevel == 2)
        {
            starsImageArray[2].color = Color.clear;
        }
        if (starGainedInLevel == 1)
        {
            starsImageArray[2].color = Color.clear;
            starsImageArray[1].color = Color.clear;
        }
        if (starGainedInLevel == 0)
        {
            starsImageArray[2].color = Color.clear;
            starsImageArray[1].color = Color.clear;
            starsImageArray[0].color = Color.clear;
        }
        int i = 0;
        while (i < 37)
        {
            starCount += allRecStar[i];
            i++;
        }


        if (starCount >= minimumStrToAllowLvl)
        {
            lockerImg.SetActive(false);
        }
        else
        {
            lockerImg.SetActive(true);
        }
    }
}
