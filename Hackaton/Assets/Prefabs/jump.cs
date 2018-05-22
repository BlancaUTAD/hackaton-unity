using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

	public float jumpHeight;
	public Rigidbody2D rigiBody;
	bool isGrounded;

	// Use this for initialization
	void Start () {
		
		jumpHeight = 20f;
		rigiBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
		
			if (isGrounded) {

				Jump (jumpHeight);
			}
		}
		
	}
		 
	void OnCollisionEnter2D(Collision2D coll)
	{


		if (coll.gameObject.name == "floor")
			{

			isGrounded = true;

		}

	}

	void OnCollisionExit2D(Collision2D coll){
	
	
		if (coll.gameObject.name == "floor") {

			isGrounded = false;
		
		}
			;

	}


	void Jump(float h){

		rigiBody.AddForce (new Vector2 (0, h), ForceMode2D.Impulse);

	}
}
