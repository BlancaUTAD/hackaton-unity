using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	
	public GameObject weaponProjectile;
	public GameObject weaponFirePoint;
	public string fireKey;
	public float projectileSpeed = 0;
	public float costFire;
    public AudioClip fireSound;

	Transform firePoint;
	GameObject temporaryProjectile;
	Vector2 playerForward;

	float pitchFactor;
	AudioSource mySound;


	//Dama: Primero tengo que coger el animador para poder modificarlo más tarde.
    private Animator animator;

    private void Start()
    {
		//Dama: en el start llamo al animador que debe estar en el mismo game object que este script.
        animator = this.GetComponent<Animator>(); //DAMA ESTUVO AQUÍ
    }

    // Use this for initialization
    void Awake () {
		firePoint = weaponFirePoint.transform;

		if (firePoint == null) 
		{
			Debug.LogError ("No FIRE POINT");
		}

		mySound = this.transform.parent.GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(fireKey))
		{
			FireWeapon();

			//Dama: cuando se dispara se setea a true, para hacer la animación de disparo. Pero solo queremos que se haga una vez. Y por eso más tarde en el LateUpdate, la seteamos falsa.
            animator.SetBool("Shoot", true);
            
			Destroy (temporaryProjectile, 10);
            
        }
    }

    void LateUpdate()
    {

		//Dama: para poder volver al estado de que deje de disparar, la seteamos a false.
        animator.SetBool("Shoot", false);
    }

    void FireWeapon (){
        
        if (weaponProjectile == null && firePoint == null) 
		{
			Debug.LogError ("No FIRE POINT and/or No Projectile");
		} 
		else 
		{
            
            playerForward = this.transform.parent.right;

			//this.GetComponentInParent<Stats> ().stamina -= costFire;

			temporaryProjectile = Instantiate (weaponProjectile, firePoint) as GameObject;
			temporaryProjectile.transform.parent = null;
			temporaryProjectile.GetComponent<Rigidbody2D> ().AddForce (playerForward * projectileSpeed);

			pitchFactor = Random.Range (0.95f, 1.05f);

			mySound.pitch = pitchFactor;
            mySound.clip = fireSound;
            mySound.Play();
            
        }
	}
}
