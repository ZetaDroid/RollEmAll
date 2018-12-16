using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTile : MonoBehaviour
{

    public GameObject gameController;
    public Transform levelFinishUI;
    private GameCon2 gameConScript;

    void Start()
    {
        gameConScript = gameController.GetComponent<GameCon2>();

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameConScript.allCollected)
            {
               
                levelFinishUI.GetComponent<LevelFinish>().LevelFinished();
            }
        }
    }
}
