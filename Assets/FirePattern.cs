using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern : MonoBehaviour {
    public GameObject[] turrets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Fire() {
        for (int i = 0; i < turrets.Length; i++) {
            turrets[i].GetComponent<TurretControl>().Fire();
        }
    }

}
