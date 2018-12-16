
using UnityEngine;

public class BotBallEndless : MonoBehaviour
{

    Vector3 position;
    Quaternion rotation;
	void Start ()
    {
        position = transform.position;
        rotation = transform.rotation;
	}
	
	
	public void ResetPos()
    {
        transform.position = this.position;
        transform.rotation = this.rotation;
        gameObject.SetActive(false);
    }
}
