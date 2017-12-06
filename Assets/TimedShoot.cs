using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedShoot : MonoBehaviour {

    public GameObject bullet;
    public float timeToFire = 5f;
    public Transform PointToShoot;

    private TimeManager localTime;
    private float timer;

    // Use this for initialization
    void Start()
    {
        localTime = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        timer = timeToFire;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= localTime.localDeltaTime();
        if (timer <= 0f)
        {
            Fire();
            timer = timeToFire;
        }
    }
    void Fire() {
        GameObject newBullet = Instantiate(bullet, PointToShoot.position, Quaternion.identity);
        newBullet.GetComponent<MoveBullet>().setMovement(PointToShoot.position, transform.position);
        newBullet.GetComponent<MoveBullet>().setSpeed(10);
    }
}
