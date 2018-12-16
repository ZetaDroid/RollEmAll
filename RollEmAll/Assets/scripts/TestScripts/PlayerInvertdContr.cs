using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerInvertdContr : MonoBehaviour
{
    public GameObject gameControllerOb;
    public GameObject popExplosion;
    public float inputMultiplier;
    private GameCon2 gameControllerScript;
    private Rigidbody rigidbody;
    private float invert = -1;
    public float forceForward;

    void Start()
    {
        gameControllerScript = gameControllerOb.GetComponent<GameCon2>();
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(0.0f, 0.0f, forceForward));
        Vector3 input = new Vector3(Input.GetAxis("Horizontal")*invert, 0.0f, Input.GetAxis("Vertical"));
        //if(Android || Mobile)
        input = new Vector3(CnInputManager.GetAxis("Horizontal")*invert, 0.0f, CnInputManager.GetAxis("Vertical"));
        //input = input.normalized;
        rigidbody.AddForce(input * inputMultiplier);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            Instantiate(popExplosion, other.transform.position, other.transform.rotation);
            gameControllerScript.CountDiamonds();
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("GroundTile"))
        {
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().WakeUp();
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.value, Random.value, Random.value);

        }
    }

}
