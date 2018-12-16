using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    public Image[] lockerArray = new Image[36];
    GameObject lockerImg;
    public int[] starArray;
    public int starCount;
    void Start()
    {
        starArray = LevelscoreManager.LoadRecordStar();
        int i = 0;
        while (i<37)
        {
            starCount += starArray[i];
            i++;
        }
        int i2 = 0;

    }
}
