using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeYourOwnGameCon : MonoBehaviour
{

    public Transform grid;
    public Camera inGameCam;

    public GameObject tempTile;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 incomingVec = hit.point;
                Instantiate(tempTile, incomingVec, Quaternion.identity);
                
            }
        }
    }
 
    public void startLevel()
    {
        grid.gameObject.SetActive(false);
        inGameCam.gameObject.SetActive(false);
    }
}
