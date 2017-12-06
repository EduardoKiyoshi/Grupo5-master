using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideScreenDestroy : MonoBehaviour {
    public float fallBoundary = -15;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= fallBoundary)
        {
            Destroy(gameObject);
        }
    }
}
