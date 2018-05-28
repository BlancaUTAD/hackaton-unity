using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

	public float jumpHeight = 2f;
	private Rigidbody2D rigiBody;
	public bool isGrounded;
	private int playerNumber;
	public float costJump;
    public AudioClip jumpSound;

    private Animator animator;

    // Use this for initialization
    void Start () {

		rigiBody = this.GetComponent<Rigidbody2D>();
		playerNumber = this.GetComponent<Stats> ().playerNumber;

        animator = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

		if (playerNumber == 1 && Input.GetKeyDown (KeyCode.W)) {
			
			if (isGrounded) {
				Jump (jumpHeight);
			}
		} 
		else if (playerNumber == 2 && Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			
			if (isGrounded) 
			{
				Jump (jumpHeight);
			}
		}
		
	}
		 
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "floor")
		{
			isGrounded = true;
            animator.SetBool("Grounded", true);
        }
	}

	void OnCollisionExit2D(Collision2D coll)
	{				
		if (coll.gameObject.tag == "floor") 
		{
			isGrounded = false;
            animator.SetBool("Grounded", false);
        }
	}

	void Jump(float h)
	{
		rigiBody.AddForce (new Vector2 (0, h), ForceMode2D.Impulse);
		this.GetComponent<Stats> ().stamina -= costJump;
        AudioSource mySound=this.transform.GetComponent<AudioSource>();
        mySound.clip = jumpSound;
        mySound.Play();
	}
}
