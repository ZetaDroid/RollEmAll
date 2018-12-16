using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScPref : MonoBehaviour
{
    private float timeCount;
    private bool startCounting;

    public GameObject scaterredPrefab;
    float allowedTime = 8.0f;

	void Sart()
    {

    }
    void Update()
    {
        if (startCounting) timeCount += Time.deltaTime;

        if (timeCount >= allowedTime)
        {
            Destroy(gameObject);
            Instantiate(scaterredPrefab, transform.position, transform.rotation);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            startCounting = true;
        }
        if (other.relativeVelocity.magnitude > 3)
        {
            timeCount = allowedTime;
        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startCounting = false;
        }

    }
}
