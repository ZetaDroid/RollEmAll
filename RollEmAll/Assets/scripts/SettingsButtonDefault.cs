using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonDefault : MonoBehaviour
{
    public Animator setAnim,exAnim;
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            clickExit();
        }
    }
    public void clickSet()
    {
        setAnim.SetBool("Open", true);
    }
    public void AnimReverseSet()
    {
        setAnim.SetBool("Open", false);
    }
    public void clickExit()
    {
        exAnim.SetBool("Open", true);
    }
    public void AnimReverseExit()
    {
        exAnim.SetBool("Open", false);
    }
}
