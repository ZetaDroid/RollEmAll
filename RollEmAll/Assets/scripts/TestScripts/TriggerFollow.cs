using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFollow : MonoBehaviour
{

    public PlayerFollw followPlayer;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followPlayer.enabled = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followPlayer.enabled = false;
        }
    }
}
