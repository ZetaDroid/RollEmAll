using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionTileInEndless : MonoBehaviour
{

    public Transform lastTileTransform;
    public GameObject diamond;
    public EndlessGameCon egc;

    public BotPnlEndless bPanel;

    Animator anim;//Animator for GROUNDTILES>>>

    private Vector3 tileReposition,lastTilePos;
    public float disposition;
    int score; 

    void Awake()
    {
        lastTilePos = lastTileTransform.position;
        score = 0;
        disposition = 0.5f;
    }

    void Update()
    {
        score = egc.score;
        
        //if (score >= 100) disposition = .9f;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("GroundTile")||other.gameObject.CompareTag("DTile")|| other.gameObject.CompareTag("mTile"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Destroy(rb);
            float random = Random.Range(0.0f, 3f);
            Vector3 newPosition = lastTilePos;
            if(random >= 0 && random <= 1)
            {
                newPosition.x = lastTilePos.x + disposition;
                newPosition.z = lastTilePos.z+1;
                lastTilePos = newPosition;
            }else if(random > 1 && random <= 2)
            {
                newPosition.x = lastTilePos.x - disposition;
                newPosition.z = lastTilePos.z+1;
                lastTilePos = newPosition;
            }
            else if(random >2 && random <= 3)
            {
                newPosition.z = lastTilePos.z + 1;    
                lastTilePos = newPosition;
            }
            other.transform.position = newPosition;
            other.transform.rotation = Quaternion.identity;
            bPanel.repositionVector = newPosition;


            if (score >= 150 && score<290) other.transform.rotation = Quaternion.Euler(0f,0f,Random.Range(-7f,7f));
            if (score >= 500 ) other.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f));
            

            anim = other.gameObject.GetComponent<Animator>();
            anim.enabled = true;
            anim.SetBool("reset", true); 
        }
        if (other.gameObject.CompareTag("DTile"))
        {
            diamond.SetActive(true);
            if (disposition <= 0.8f)
            {
                disposition += .00035f;
            }
            else
            {
                disposition = 0.85f;
            }
        }
        if (other.gameObject.CompareTag("mTile"))
        {
            if (score >= 290)
            {
                other.gameObject.GetComponent<TileMovement>().enabled = true;
                other.gameObject.GetComponent<TileMovement>().Move();
            }
        }
        if (other.gameObject.CompareTag("npb"))
        {
            Destroy(other.gameObject);
        }

    }
    
}
