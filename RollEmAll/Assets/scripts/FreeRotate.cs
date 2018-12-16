 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotate : MonoBehaviour
{
    public Vector3 pivot;
    public Vector3 axisOfRotation;
    public float rotationSpeed;
	void Update ()
    {
        transform.RotateAround(pivot, axisOfRotation, rotationSpeed*Time.deltaTime);
    }
}
