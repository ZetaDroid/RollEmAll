using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeranimCon : MonoBehaviour
{

    private Animator anim;
    public GameObject bubble;
    public float timer;//make it Private
    private bool timerStart;
    private AudioSource audio;
    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = bubble.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                timerStart = false;
                timer = 0;
                anim.SetBool("PlayerInBubble", false);
                bubble.SetActive(false);
                audio.Stop();
            }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            if (!timerStart)
            {
                audio.Play();
                bubble.SetActive(true);
                anim.SetBool("PlayerInBubble", true);
                timerStart = true;
            }
            
        }
    }
    

}
