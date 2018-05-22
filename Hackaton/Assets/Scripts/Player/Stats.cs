using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public float life;
	public float stamina;
	//[HideInInspector]
	public int playerNumber;

	// Use this for initialization
	void Start () 
	{
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
}
