using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInputDebug : MonoBehaviour
{
    public Text output;
    void Start()
    {
      
    }
    void Update()
    {
        output.text = "horizontal: " + Input.GetAxis("Horizontal");
        
    }
	
}
