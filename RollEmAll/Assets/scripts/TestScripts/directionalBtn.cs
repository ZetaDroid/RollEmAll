using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalBtn : MonoBehaviour
{
    public float forceMultiplier;
    public GameObject player;

   
	public void PushForward()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceMultiplier);
    }
    public void PushBack()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.back * forceMultiplier);
    }
    public void PushLeft()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.left * forceMultiplier);
    }
    public void PushRight()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.right * forceMultiplier);
    }

}
