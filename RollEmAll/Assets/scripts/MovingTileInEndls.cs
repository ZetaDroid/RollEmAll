using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTileInEndls : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        if (player.position.z > transform.position.z)
        {
           gameObject.AddComponent<Rigidbody>();
           gameObject.GetComponent<Rigidbody>().WakeUp();
           gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        }
    }
}
