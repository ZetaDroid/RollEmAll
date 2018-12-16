using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
   
    public int stars;
    public LevelFinish levelFinish;

    void Update()
    {
        if (!levelFinish.levelFailed)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad;
        }
    }
    
}
