using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public float life;
	public float stamina;
	public int playerNumber;
    public AudioClip deathSound;
    public AudioClip staminaSound;
	Rigidbody2D rigidBody;
	public float staminaIncrease;
    public AudioClip[] frasesList;
    public float timeWaitFrase;
    public float elapsedWaitFrase;

    private Animator animator;

    // Use this for initialization
    void Start () 
	{
        animator = this.GetComponent<Animator>();
		rigidBody = this.GetComponent<Rigidbody2D> ();
		staminaIncrease = 0.1f;

        elapsedWaitFrase = timeWaitFrase;
        

        // Asignamos el player number a cada jugador, nose si será necesario.
        GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) 
		{
			if (players[i] != this.gameObject)
			{
				if (players [i].GetComponent<Stats> ().playerNumber == 1) 
				{
					this.playerNumber = 2;
				} 
				else 
				{
					this.playerNumber = 1;
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Lava")
		{
			life = 0;
		}
	}


     void Update()
    {
        animator.SetFloat("Life", life);

		//Debug.Log(isMoving (rigidBody));

		addStamina (isMoving (rigidBody));

        if (elapsedWaitFrase <= 0)
        {
            int result = (int)Random.Range(0.0f, (frasesList.Length - 1));
            AudioSource mySound2 = this.transform.GetComponent<AudioSource>();
            if (result < frasesList.Length)
            {
                mySound2.clip = frasesList[result];
                mySound2.Play();
            }
            elapsedWaitFrase = timeWaitFrase;
        }
        else
        {
            elapsedWaitFrase -= Time.deltaTime;
        }


    }

	bool isMoving(Rigidbody2D r){
	
		if ((r.velocity).magnitude >= Mathf.Abs(0.5f)) {
		
			return true;
		}

		return false;
	
	}

	void addStamina(bool moving){

		if (moving == false) {

			stamina = stamina + staminaIncrease;
		}
	
	}

    public void PlaySoundDead()
    {
        if (life <= 0)
        {
            /*if (this.transform.Find("Weapon").gameObject != null)
            {
               GameObject.Destroy(this.transform.Find("Weapon").gameObject);
            }
           */ GameObject.Destroy(this.transform.Find("Weapon").gameObject);
            AudioSource mySound = this.transform.GetComponent<AudioSource>();
            mySound.clip = deathSound;
            mySound.Play();
        }
        else if (stamina <= 0)
        {
            AudioSource mySound = this.transform.GetComponent<AudioSource>();
            mySound.clip = staminaSound;
            mySound.Play();
        }
    }
}
