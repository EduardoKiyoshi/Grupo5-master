using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTimedPlayer : MonoBehaviour {

	public float speed = 4f;
	private float x = 0;
	private float y = 0;

	void Update(){
		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical");

		//transform.localPosition += new Vector3(x,y)* speed * Time.deltaTime / Time.timeScale;
		//Debug.Log (Time.deltaTime / Time.timeScale);
		GetComponent<Rigidbody2D>().velocity = new Vector2(x,y)*speed * Time.deltaTime / Time.timeScale;
	}
	private void FixedUpdate()
	{
		
		// Move the character
		//GetComponent<Rigidbody2D>().velocity = new Vector2(x,y) * (speed * Time.deltaTime / Time.timeScale);
	}



}
