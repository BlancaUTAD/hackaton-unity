using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {


	public float projectileDamage = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Colision Disparo");
		if (col.gameObject.tag == "Player") 
		{
			col.gameObject.GetComponent<Stats> ().life -= projectileDamage;
		}
		Destroy (this.gameObject);
	}
}
