using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject bullet;
    public float force = 25;
    //public GameObject[] bullets;
    private GameObject uniqueBullet = null;

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    private float TimeToFire = 0;
    Transform firePoint;
    private float distance = 100;

    void Start()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint Object missing!");
        }
    }

	
	// Update is called once per frame
	void Update () {
        //fire();
        if (fireRate == 0)
        {
            //if (Input.GetMouseButtonDown(0))
            if (Input.GetButtonDown("Fire1"))
                fire();
        }
        else {
            if(Input.GetButton("Fire1") && Time.time > TimeToFire)
            {
                //Rate, not delay
                TimeToFire = Time.time + 1 / fireRate;
                fire();
            }
        }        
    }
    void fire() {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, distance, whatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*distance, Color.cyan);

        if (hit.collider != null) { 
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            //uniqueBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
        }

    }
    void moveBullet() {
        
    }
}
