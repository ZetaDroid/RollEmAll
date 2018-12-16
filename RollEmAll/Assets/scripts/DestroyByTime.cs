using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float lifetime = 2;
        Destroy(gameObject, lifetime);
	}
}
