using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTrigger : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 pivot;
    public Vector3 rotationAxis;
    public float startingRotation;
    public GameObject triggerObject;
    private TriggerScript triggerScript; 
    

    private Vector3 restingPosition;
    private Quaternion restingRotation;
    private bool isTriggered = false;
   
    void Start()
    {
       triggerScript = triggerObject.GetComponent<TriggerScript>();
        restingPosition = transform.position;
        restingRotation = transform.rotation;
        transform.RotateAround(pivot, rotationAxis, startingRotation);
    }
    void Update()
    {
        if (isTriggered)
        {
            if (transform.position.y < restingPosition.y)
            {
                transform.RotateAround(pivot, rotationAxis, rotationSpeed);
            }
            else
            {
                transform.position = restingPosition;
                transform.rotation = restingRotation;
                isTriggered = false;
            }
            
        }

        Trigger();
    }

    public void Trigger()
    {
       // if (isTriggered == null)
        {
            isTriggered = triggerScript.istriggered;
        }
    }

    
}
