using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
    public Vector2 moveDirection;
    private Vector2 initialPos;
    private Vector2 finalPos;
    public int speed;

    private TimeManager localTime;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localTime = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update () {
        //Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - _gravity * localTime.localDeltaTime());
        //rb.MovePosition(newPosition);

        
    }
    void FixedUpdate() {
        //Vector2 newPosition = transform.position + moveDirection * speed * localTime.localDeltaTime();
            //new Vector2(moveDirection.position.x + speed * localTime.localDeltaTime(), moveDirection.position.y + speed * localTime.localDeltaTime());
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDirection * speed * localTime.localDeltaTime());

        //float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(initialPos, finalPos, step);
    }
    public void setMovement(Vector2 initialPos, Vector2 finalPos) {
        moveDirection = (initialPos - finalPos).normalized;
    }
    public void setSpeed(int speed) {
        this.speed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
