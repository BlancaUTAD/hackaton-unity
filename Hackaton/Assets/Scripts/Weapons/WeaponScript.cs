using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	
	public float fireRate = 0;
	public float weaponCooldownPeriodInSeconds = 0;
	public GameObject weaponProjectile;
	public LayerMask notToHit;
	public string fireKey;

	Transform firePoint;
	float timeStamp = 0;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) 
		{
			Debug.LogError ("No FIRE POINT");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown(fireKey))
			{
				FireWeapon();
				timeStamp = Time.time + weaponCooldownPeriodInSeconds;
			}
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
				Instantiate (weaponProjectile, firePoint);
			}
		}
	}
}
