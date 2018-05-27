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
    public AudioClip fireSound;

	Transform firePoint;
	float timeStamp = 0;
	GameObject temporaryProjectile;
	Vector2 playerForward;

    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

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
		if (Input.GetKeyDown(fireKey))
		{
			FireWeapon();
            animator.SetBool("Shoot", true);
            
            timeStamp = Time.time + weaponCooldownPeriodInSeconds;
			Destroy (temporaryProjectile, 10);
            
        }
    }

    void LateUpdate()
    {
        animator.SetBool("Shoot", false);
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
                

                playerForward = this.transform.parent.right;

				this.GetComponentInParent<Stats> ().stamina -= costFire;

				temporaryProjectile = Instantiate (weaponProjectile, firePoint) as GameObject;
				temporaryProjectile.transform.parent = null;
				temporaryProjectile.GetComponent<Rigidbody2D> ().AddForce (playerForward * projectileSpeed);
                AudioSource mySound = this.transform.parent.GetComponent<AudioSource>();
                mySound.clip = fireSound;
                mySound.Play();
                
            }
            
        }
	}
}
