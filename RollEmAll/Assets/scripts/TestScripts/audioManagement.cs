using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioManagement : MonoBehaviour
{
    public AudioClip[] audioClips = new AudioClip[6];
    private AudioSource audio;
    bool toFinish = true;
    

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = getClip();
        audio.Play();
        
    }


    public AudioClip getClip()
    {
        int i = (int)Random.Range(0f, 3f);
        
        print("Ran#"+i);
        return audioClips[i];
    }

    public void PlayLevelPassed()
    {
        if (toFinish)
        {            
            audio.Stop();
            audio.clip = audioClips[5];
            audio.loop = false;
            audio.Play();
            toFinish = false;
        }
    }
    public void PlayLevelFailed()
    {
        if (toFinish)
        {
            audio.Stop();
            audio.clip = audioClips[4];
            audio.loop = false;
            audio.Play();
            toFinish = false;
        }
    }

}
