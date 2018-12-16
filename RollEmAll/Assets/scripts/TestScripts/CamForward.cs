using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamForward : MonoBehaviour
{
    public GameObject player;
    private Vector3 clearence;
    void Start()
    {
        clearence = player.transform.position - transform.position;
    }
    void Update()
    {
        if (player.transform.position.y > -3)
        {
            Vector3 newPosition = player.transform.position - clearence;
            transform.position = new Vector3(0.0f, newPosition.y, newPosition.z);
        }
    }
	
}
