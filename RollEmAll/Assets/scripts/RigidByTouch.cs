using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidByTouch : MonoBehaviour
{
    public GameObject enemyInert;
    GameObject sphere, cube;

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitable"))
        {
            sphere = enemyInert.transform.Find("Sphere").gameObject;
            sphere.transform.rotation = other.transform.Find("Sphere").rotation;
            Destroy(other.gameObject);
            Instantiate(enemyInert, other.transform.position, Quaternion.identity);
           // sphere.transform.LookAt(gameObject.transform);
        }
    }
}
