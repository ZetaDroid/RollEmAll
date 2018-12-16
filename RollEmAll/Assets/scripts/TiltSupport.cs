using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltSupport : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
	
}
