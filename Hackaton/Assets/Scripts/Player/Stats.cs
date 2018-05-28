using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public float life;
	public float stamina;
	public int playerNumber;
    public AudioClip deathSound;
    public AudioClip staminaSound;

    private Animator animator;

    // Use this for initialization
    void Start () 
	{
        animator = this.GetComponent<Animator>();
        

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
			GameObject.Destroy (this);
		}
	}


     void Update()
    {
        animator.SetFloat("Life", life);

        if (life<=0)
        {
			GameObject.Destroy(this.transform.Find ("Weapon").gameObject);

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
