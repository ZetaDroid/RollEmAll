using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }else
        {
            Destroy(other.gameObject);
        }
        
    }
	
}
