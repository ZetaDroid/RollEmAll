using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimConScript : MonoBehaviour
{

    Animator anim;
    public Transform handleBar;
    public Image starImageOnLevelFinished;
    public LevelFinish levelfinish;
    bool starFall = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (handleBar.position.x <= transform.position.x)
        {
            anim.SetTrigger("fall");
            starImageOnLevelFinished.color = Color.clear;
            if (!starFall)
            {
                levelfinish.stars--;
                starFall = true;
            }
        }
    }
}
