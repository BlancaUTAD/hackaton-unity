using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

	public float jumpHeight;
	private Rigidbody2D rigiBody;
	bool isGrounded;
	private int playerNumber;

	// Use this for initialization
	void Start () {

		jumpHeight = 10f;
		rigiBody = this.GetComponent<Rigidbody2D>();
		playerNumber = this.GetComponent<Stats> ().playerNumber;

	}
	
	// Update is called once per frame
	void Update () {

		if (playerNumber == 1 && Input.GetKeyDown (KeyCode.W)) {
			
			if (isGrounded) {
				Debug.Log ("Salta1");
				Jump (jumpHeight);
			}
		} 
		else if (playerNumber == 2 && Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			
			if (isGrounded) 
			{
				Debug.Log ("Salta2");
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
