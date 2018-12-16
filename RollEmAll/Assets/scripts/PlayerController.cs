using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;


public class PlayerController : MonoBehaviour
{
    public GameObject gameControllerObject;
    public GameObject mildExplosiion;
    private GameController gameControllerScript;
    private Vector3 input;
    public float speed;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameControllerScript = gameControllerObject.GetComponent<GameController>();
        
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));//or
        input = new Vector3(CnInputManager.GetAxis("Horizontal"), 0.0f, CnInputManager.GetAxis("Vertical"));
        //input = input.normalized;
        rb.AddForce(input * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            gameControllerScript.CountDiamonds();
            Instantiate(mildExplosiion, other.transform.position, other.transform.rotation);
        }
      
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TriggerTile"))
        {
            collision.gameObject.GetComponent<TriggerScript>().Triggered();

        }
    }
}
