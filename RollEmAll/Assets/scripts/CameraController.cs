using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOffset;
    Vector3 camPosition;
    Quaternion camRotation;
    bool rotate;
	// Use this for initialization
	void Start ()
    {
        cameraOffset = transform.position - player.transform.position; 

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.y > -3) 
        {
            transform.position = (player.transform.position + cameraOffset);
        }
        if (rotate)
        {
            transform.RotateAround(player.transform.position, Vector3.up, .02f);
        }
        
	}

    public void Paused()
    {
        Admanager.CheckForAd();
        camPosition = transform.position;
        camRotation = transform.rotation;
        rotate = true;
    }
    public void Resumed()
    {
        rotate = false;
        transform.position = camPosition;
        transform.rotation = camRotation;
    }
}
