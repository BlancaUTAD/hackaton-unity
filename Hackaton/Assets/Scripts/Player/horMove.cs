using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horMove : MonoBehaviour {

	public float horImpulse;
	Rigidbody2D rigid;
	public float costMovementBySecond;
	private Stats myStats;
	private float maxVelocity;

	private Transform transformPlayer1;
	private Transform transformPlayer2;

	// Use this for initialization
	void Start () 
	{
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
		horImpulse = 20;
		maxVelocity = 5f;
		myStats = this.GetComponent<Stats> ();
	}

	// Update is called once per frame
	void Update () {
	
		if (myStats.playerNumber == 1) 
		{
			transformPlayer1 = GetComponent<Transform> ();

			if (Input.GetKey (KeyCode.A)) 
			{
				if (transformPlayer1.eulerAngles.z < 180) 
				{
					transformPlayer1.Rotate (0, 0, 180);
				}

				moveHor (horImpulse);
				myStats.stamina -= (costMovementBySecond * Time.deltaTime);

			} 
			else if (Input.GetKey (KeyCode.D)) 
			{
				if (transformPlayer1.eulerAngles.z >= 180) 
				{
					transformPlayer1.Rotate (0, 0, 180);
				}

				moveHor (horImpulse);
				myStats.stamina -= (costMovementBySecond * Time.deltaTime);
			}
		} 
		else if (myStats.playerNumber == 2) 
		{
			transformPlayer2 = GetComponent<Transform> ();
			if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				if (transformPlayer2.eulerAngles.z < 180) 
				{
					transformPlayer2.Rotate (0, 0, 180);
				}
				moveHor (horImpulse);
				myStats.stamina -= (costMovementBySecond * Time.deltaTime);
			} 
			else if (Input.GetKey (KeyCode.RightArrow)) 
			{
				if (transformPlayer2.eulerAngles.z >= 180) 
				{
					transformPlayer2.Rotate (0, 0, 180);
				}
				moveHor (horImpulse);
				myStats.stamina -= (costMovementBySecond * Time.deltaTime);
			}
		}

	}


	void moveHor(float impHor)
	{
		if (rigid.velocity.magnitude <= maxVelocity)
		rigid.AddForce (transform.right * impHor);
			
	}
}