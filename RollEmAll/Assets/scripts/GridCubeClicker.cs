using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCubeClicker : MonoBehaviour
{

    public MakeYourOwnGameCon mYGC;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = mYGC.tempTile;
            if (go != null)
            {
                Instantiate(go, transform.position, transform.rotation);
            }else
            {
                Debug.Log("Select a tile Type");
            }
        }
    }

}
