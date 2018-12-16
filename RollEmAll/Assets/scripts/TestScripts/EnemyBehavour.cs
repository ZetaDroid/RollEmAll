using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavour : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 15;
    bool toRotateCube;

    Animator anim;
    GameObject sphere;
    GameObject cube;

    Transform initialTransform;

    void Awake()
    {
        sphere = transform.Find("Sphere").gameObject;
        cube = transform.Find("Cube").gameObject;
        anim = GetComponent<Animator>();
        initialTransform = cube.transform;
    }
    void FixedUpdate()
    {
        if (player != null && player.position.y > -1)
        {
            sphere.transform.LookAt(player);
        }
        else
        {
            sphere.transform.rotation = Quaternion.Lerp(sphere.transform.rotation, Quaternion.identity, Time.deltaTime);
        }
        
        if (toRotateCube)//Changed Here;
        {
            cube.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
        }
        
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //transform.LookAt(other.transform);
            anim.SetBool("ToOpen", true);
            toRotateCube = true;
            //play audioClip;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("ToOpen", false);
            toRotateCube = false;
            cube.transform.rotation = Quaternion.Slerp(transform.rotation, initialTransform.rotation,  Time.deltaTime);
            //play audoiClip;
        }
    }


}
