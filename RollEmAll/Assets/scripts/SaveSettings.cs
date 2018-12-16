using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveSettings : MonoBehaviour
{

    public Animator anim;
    public Slider volumeSlider;
    public Button justD1, justD2, both, keyboard;
    public bool keepD1, keepD2;
    public float vol;

    void Awake()
    {
        keepD1 = Settings.LoadToKeepD1();
        keepD2 = Settings.LoadToKeepD2();
        vol = Settings.LoadVolume();
        AudioListener.volume = vol;
        volumeSlider.value = vol;

        if (keepD1 && !keepD2)
        {
            justD1.targetGraphic.color = Color.cyan;
        }
        if (!keepD1 && keepD2)
        {
            justD2.targetGraphic.color = Color.cyan;
        }
        if (keepD1 && keepD2)
        {
            both.targetGraphic.color = Color.cyan;
        }
        if (!keepD1 && !keepD2)
        {
            keyboard.targetGraphic.color = Color.cyan;
        }


    }
    

    void Update()
    {
        AudioListener.volume = volumeSlider.value;
        

    }
    public void SaveSettingsButton()
    {
        anim.SetBool("Open", false);
        vol = volumeSlider.value;
        Settings.SaveSettings(keepD1,keepD2,vol);

    }
    public void KeepJustD1()
    {
        keepD1 = true;
        keepD2 = false;
        justD1.targetGraphic.color = Color.cyan;
        justD2.targetGraphic.color = Color.white;
        both.targetGraphic.color = Color.white;
        keyboard.targetGraphic.color = Color.white;
    }
    public void KeepJustD2()
    {
        keepD1 = false;
        keepD2 = true;
        justD1.targetGraphic.color = Color.white;
        justD2.targetGraphic.color = Color.cyan;
        both.targetGraphic.color = Color.white;
        keyboard.targetGraphic.color = Color.white;
    }
    public void KeepBoth()
    {
        keepD1 = true;
        keepD2 = true;
        justD1.targetGraphic.color = Color.white;
        justD2.targetGraphic.color = Color.white;
        both.targetGraphic.color = Color.cyan;
        keyboard.targetGraphic.color = Color.white;
    }
    public void Keyboard()
    {
        keepD1 = false;
        keepD2 = false;
        justD1.targetGraphic.color = Color.white;
        justD2.targetGraphic.color = Color.white;
        both.targetGraphic.color = Color.white;
        keyboard.targetGraphic.color = Color.cyan;
    }

}
