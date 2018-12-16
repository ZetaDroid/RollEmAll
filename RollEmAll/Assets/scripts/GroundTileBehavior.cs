using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileBehavior : MonoBehaviour
{
    public float rotationLimit;
    public float rotationIncrement;
    private float currentRotation=0;
    private bool isClockwise = true;


    void Update ()
    {
       
        RotateToLimit();
	}
    void RotateToLimit()
    {
        if (isClockwise)

        {

            transform.Rotate(new Vector3(0.0f, rotationIncrement, 0.0f) * Time.deltaTime);
            currentRotation = currentRotation + (rotationIncrement * Time.deltaTime);
            if (currentRotation > rotationLimit) isClockwise = false;

        }
        else
        {
            transform.Rotate(new Vector3(0.0f, -rotationIncrement, 0.0f) * Time.deltaTime);
            currentRotation = currentRotation - (rotationIncrement * Time.deltaTime);
            if (currentRotation < -rotationLimit) isClockwise = true;
        }
    }

   
}
