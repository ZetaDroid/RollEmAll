using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTiles : MonoBehaviour
{

    public Vector3 axisOfRotation;
    public float speedOfRotation;
    void FixedUpdate()
    {
        transform.Rotate(axisOfRotation * speedOfRotation * Time.deltaTime,Space.Self);
    }
}
