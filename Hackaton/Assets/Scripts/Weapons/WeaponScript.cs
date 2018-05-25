using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	
	public float weaponCooldownPeriodInSeconds = 0;
	public GameObject weaponProjectile;
	public GameObject weaponFirePoint;
	//public LayerMask notToHit;
	public string fireKey;
	public float projectileSpeed = 0;
	public float costFire;

	Transform firePoint;
	float timeStamp = 0;
	GameObject temporaryProjectile;
	// Use this for initialization
	void Awake () {
		firePoint = weaponFirePoint.transform;

		if (firePoint == null) 
		{
			Debug.LogError ("No FIRE POINT");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(fireKey))
		{
			FireWeapon();
			timeStamp = Time.time + weaponCooldownPeriodInSeconds;
			Destroy (temporaryProjectile, 10);
		}

	}

	void FireWeapon (){
		if (weaponProjectile == null && firePoint == null) 
		{
			Debug.LogError ("No FIRE POINT and/or No Projectile");
		} 
		else 
		{
			if (timeStamp <= Time.time) 
			{
				this.GetComponentInParent<Stats> ().stamina -= costFire;
				temporaryProjectile = Instantiate (weaponProjectile, firePoint) as GameObject;
				temporaryProjectile.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * projectileSpeed);
			}
		}
	}
}
