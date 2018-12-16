using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerControllerForEndless : MonoBehaviour
{
    public EndlessGameCon egc;
    public GameObject explosionPrefab;
    public float speed;
    private Rigidbody rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //if(Android || Mobile)
        input = new Vector3(CnInputManager.GetAxis("Horizontal"), 0.0f, CnInputManager.GetAxis("Vertical"));

        input *= speed;
        rb.AddForce(input);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
            egc.AddScore();
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("GroundTile")||other.gameObject.CompareTag("DTile")||other.gameObject.CompareTag("mTile"))
        {
            anim = other.gameObject.GetComponent<Animator>();
            anim.SetBool("reset", false);
            anim.enabled = false;
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().WakeUp();
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1,1), Random.Range(-1,1), Random.Range(-1,1));

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Destroy(other.gameObject);
        }
    }
}
