using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameObject[] players;
	public float timeMatch;
	private float contTimeMatch;

	void Start () 
	{
		players = new GameObject[2];
		players = GameObject.FindGameObjectsWithTag ("Player");
		contTimeMatch = 0;
	}

	void Update () 
	{
		for (int i = 0; i < players.Length; i++) 
		{
			if (players [i].GetComponent<Stats> ().life <= 0 || players [i].GetComponent<Stats> ().stamina <= 0) 
			{
				EndGameDead(players [i]);
				break;
			}
		}

		if (contTimeMatch < timeMatch) 
		{
			contTimeMatch += Time.deltaTime;
			Debug.Log ("contTimeMatch" + contTimeMatch);
		}

		else
		{
			EndGameTime ();
		}
	}

	private void EndGameDead(GameObject looser)
	{
		if (looser.GetComponent<Stats> ().playerNumber == 1) 
		{
			Debug.Log ("Player 2 Winner");
		} 
		else 
		{
			Debug.Log ("Player 1 Winner");
		}
	}

	private void EndGameTime()
	{
		if (players [0].GetComponent<Stats> ().stamina > players [1].GetComponent<Stats> ().stamina)
		{
			Debug.Log("Player " +  players [0].GetComponent<Stats> ().playerNumber + " Winner");
		} 
		else if (players [1].GetComponent<Stats> ().stamina > players [0].GetComponent<Stats> ().stamina) 
		{
			Debug.Log("Player " +  players [1].GetComponent<Stats> ().playerNumber +  "Winner");
		} 
		else 
		{
			Debug.Log ("Tie");
		}
	}
}
