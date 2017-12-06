using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour {
    public GameObject bullet;
    public Transform PointToShoot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, PointToShoot.position, Quaternion.identity);
        newBullet.GetComponent<MoveBullet>().setMovement(PointToShoot.position, transform.position);
        newBullet.GetComponent<MoveBullet>().setSpeed(10);
    }
}
