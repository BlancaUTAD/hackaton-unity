using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horMove : MonoBehaviour {

	public float horImpulse;
	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {


		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
		horImpulse = 160;
	}




	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.A)) {

			moveHor (-horImpulse);
		}

		if (Input.GetKey (KeyCode.D)) {

			moveHor (horImpulse);
		}

	}


	void moveHor(float impHor){

		rigid.AddForce (transform.right * impHor);
			
	}
}