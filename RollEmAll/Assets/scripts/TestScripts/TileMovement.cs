using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{

    private bool toMove, toRight;
    public Vector3 directionOfMovement;
    public float speedOfMovement;
    public float limitOfMovement;
    private float counter;

    void Start()
    {
        toMove = true;
        toRight = true;
        Debug.Log("DTime: " + Time.deltaTime);
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (toMove)
        {
            if (toRight)
            {
                transform.Translate(directionOfMovement * speedOfMovement);
                counter += speedOfMovement;
                if (counter >= limitOfMovement)
                {
                    toRight = false;
                    speedOfMovement = -speedOfMovement;
                    limitOfMovement = -limitOfMovement;
                }
            }
            else
            {
                transform.Translate(directionOfMovement * speedOfMovement);
                counter += speedOfMovement;
                if (counter <= limitOfMovement)
                {
                    toRight = true;
                    speedOfMovement = -speedOfMovement;
                    limitOfMovement = -limitOfMovement;
                }
            }
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toMove = false;
        }
    }

    public void Move()
    {
        toMove = true;
    }
}
