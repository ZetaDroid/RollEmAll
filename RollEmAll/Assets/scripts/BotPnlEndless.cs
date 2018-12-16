using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPnlEndless : MonoBehaviour
{
    public Transform camera,player,spawnPoint;
    public Vector3 repositionVector;
    public GameObject npb;
    public EndlessGameCon egc;

    public EnemyBehavour[] enemyBots;

    bool toSpawn;
    float npbRandomiser = 0,npbRandCheckVal = 3f;
    void Update()
    {
        Reposition();
        
    }
	public void Reposition()
    {
        if (camera.position.z > transform.position.z)
        {
            repositionVector.z += 5;
            transform.position = repositionVector;
            npbRandomiser = Random.Range(0f, 10f);
            if (npbRandomiser <= npbRandCheckVal)
            {
                toSpawn = true;
            }
            npbRandCheckVal += 0.05f;

            enemyBots[0].player = this.player;
            enemyBots[1].player = this.player;

        }
        float dist = Vector3.Distance(camera.position, transform.position);
        if (dist < 14 && toSpawn)
        {
            
            Vector3 npbPos = new Vector3(transform.position.x, 7f, transform.position.z);
            GameObject blueBall = Instantiate(npb, npbPos, Quaternion.identity);
            if(blueBall != null)
            {
                enemyBots[0].player = blueBall.transform;
                enemyBots[1].player = blueBall.transform;
            }
            toSpawn = false;
        }
        if (toSpawn)
        {
            enemyBots[0].player = this.spawnPoint;
            enemyBots[1].player = this.spawnPoint;
        }
    }
}
