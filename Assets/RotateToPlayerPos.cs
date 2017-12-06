using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayerPos : MonoBehaviour {
    public int rotationOffset = 0;

    private float nextTimeToSearch = 0;
    private Transform target;
	
    // Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null)
            Debug.Log("Implementar e se o player morreu");
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            FindPlayer();
            return;
        }
        Turn();
    }

    void Turn()
    {
        Vector3 diff = target.position - transform.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                target = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }

    }
}
