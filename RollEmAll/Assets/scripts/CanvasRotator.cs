using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    public bool isClockwise, isToRotate;
    public float rotationSpeed;
    public float rotationLimit;
    public float rotationCounter;

    void Start()
    {
        float rotationY = CanvasContainerRotation.LoadRotation();
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        rotationCounter = rotationY;
    }
    
    void Update()
    {
        RotateContainer();
    }
    public void RotateContainer()
    {
        if (isToRotate)
        {

            if (isClockwise)
            {
                transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
                rotationCounter += rotationSpeed;
                if (rotationCounter > rotationLimit)
                {
                    isToRotate = false;
                    if(rotationLimit == 360)
                    {
                        rotationCounter = 0;
                        rotationLimit = 0;
                        transform.rotation = Quaternion.Euler(0.0f, rotationCounter, 0.0f);
                    }
                    rotationCounter = rotationLimit;
                    transform.rotation = Quaternion.Euler(0.0f, rotationCounter, 0.0f);
                }
            }
            else
            {
                transform.RotateAround(transform.position, Vector3.down, rotationSpeed);
                rotationCounter -= rotationSpeed;
                if (rotationCounter < rotationLimit)
                {
                    isToRotate = false;
                    if (rotationLimit == -90)
                    {
                        rotationCounter = 270;
                        rotationLimit = 270;
                        transform.rotation = Quaternion.Euler(0.0f, rotationCounter, 0.0f);
                    }
                    rotationCounter = rotationLimit;
                    transform.rotation = Quaternion.Euler(0.0f, rotationCounter, 0.0f);
                }
            }
        }
    }
    public void StartRotation( float rotationlim)
    {
        isToRotate = true;        
        rotationLimit = rotationlim;
        if(rotationlim == 360)
        {
            CanvasContainerRotation.SaveRotation(0f);
        }
        else
        {
            CanvasContainerRotation.SaveRotation(rotationLimit);
        }
    }
    public void SetIsClockwise(bool boolean)
    {
        isClockwise = boolean;
    }
}
