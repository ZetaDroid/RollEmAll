using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBtn : MonoBehaviour
{
    public Rigidbody playerRb;
	void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    public void Click()
    {
        playerRb.velocity = Vector3.zero;
    }
}
