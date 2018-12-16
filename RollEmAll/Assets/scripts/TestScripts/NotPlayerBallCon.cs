using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPlayerBallCon : MonoBehaviour
{

    public GameObject gameCotroller;
    public GameObject popExplosion;
    private GameCon2 gameControllerScript;

    void Start()
    {
        gameControllerScript = gameCotroller.GetComponent<GameCon2>();
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
}
