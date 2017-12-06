using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {	
	public Transform []positions;
	public Transform currentPos;
	public float speed = 2.0f;

	private Transform platform;
	private Rigidbody2D rb;
	private int pointSelected;
	private TimeManager localTime;

	void Start(){
		platform = transform;
		localTime = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();
        /*
		pointSelected = 0;
		currentPos = positions [pointSelected];
		transform.position = currentPos.position;
        */
		rb =  GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
        movePlatform();
    }
    void movePlatform() {        
		Vector2 newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y);
		rb.MovePosition(newPosition);	
        /*
        if (pointSelected < positions.Length - 1)
        {
            Vector2 moveDirection = positions[pointSelected].position - positions[pointSelected + 1].position;
            //Vector2 newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y);
            //rb.MovePosition(newPosition);
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDirection * speed * localTime.localDeltaTime());
            if (positions[pointSelected].position == positions[pointSelected + 1].position)
            {
                pointSelected++;
            }
        }
        else { pointSelected = 0; }
        */

        /*
		if (transform.position == currentPos.position)
			pointSelected++;*/
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeDirTrigger"))
        {
            speed *= -1;
            Flip();
        }

    }
}
