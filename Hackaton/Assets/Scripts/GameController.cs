using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameObject[] players;
	//public float timeMatch = 5;
	//private float contTimeMatch;
	[HideInInspector]
	public bool countDownFinished;

	public float staminaPlayer1;
	public float staminaPlayer2;

	void Start () 
	{
		players = new GameObject[2];
		players = GameObject.FindGameObjectsWithTag ("Player");
		//contTimeMatch = 0;
		countDownFinished = false;
		StartCoroutine (countDown ());
	}

	void Update () 
	{
		if (players [0].GetComponent<Stats> ().playerNumber == 1) 
		{
			staminaPlayer1 = players [0].GetComponent<Stats> ().stamina;
			staminaPlayer2 = players [1].GetComponent<Stats> ().stamina;
		}
		else 
		{
			staminaPlayer2 = players [0].GetComponent<Stats> ().stamina;
			staminaPlayer1 = players [1].GetComponent<Stats> ().stamina;
		}

		for (int i = 0; i < players.Length; i++) 
		{
			if (players [i].GetComponent<Stats> ().life <= 0 || players [i].GetComponent<Stats> ().stamina <= 0) 
			{
                StartCoroutine(EndGameDead(players [i]));
				break;
			}
		}

		/*if (contTimeMatch < timeMatch) 
		{
			contTimeMatch += Time.deltaTime;
		} 
		else 
		{
			EndGameTime ();
		}*/
	}

    private IEnumerator EndGameDead(GameObject looser)
	{
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<horMove>().enabled = false;
            players[i].GetComponent<jump>().enabled = false;
            WeaponScript myWS = players[i].GetComponentInChildren<WeaponScript>();
            if (myWS != null)
                myWS.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Stats>().PlaySoundDead();
        }

        yield return new WaitForSeconds(2);  

		if (looser.GetComponent<Stats> ().playerNumber == 1) 
		{
            //contTimeMatch = 0f;
            GameController.FindObjectOfType<Camera>().GetComponent<ControlFlowScenes>().loadSceneRandom(2);
        } 
		else 
		{
            //contTimeMatch = 0f;
            GameController.FindObjectOfType<Camera>().GetComponent<ControlFlowScenes>().loadSceneRandom(1);
        }		
	}

    /*private IEnumerator EndGameTime()
	{
        if (players [0].GetComponent<Stats> ().stamina > players [1].GetComponent<Stats> ().stamina)
		{
			Debug.Log("Player " +  players [0].GetComponent<Stats> ().playerNumber + " Winner");
            //contTimeMatch = 0f;
            GameController.FindObjectOfType<Camera>().GetComponent<ControlFlowScenes>().loadSceneRandom(1);
        } 
		else if (players [1].GetComponent<Stats> ().stamina > players [0].GetComponent<Stats> ().stamina) 
		{
			Debug.Log("Player " +  players [1].GetComponent<Stats> ().playerNumber +  "Winner");
            //contTimeMatch = 0f;
            GameController.FindObjectOfType<Camera>().GetComponent<ControlFlowScenes>().loadSceneRandom(2);
        } 
		else 
		{
			Debug.Log ("Tie");
            //contTimeMatch = 0f;
            GameController.FindObjectOfType<Camera>().GetComponent<ControlFlowScenes>().loadSceneRandom(0);
        }
	}*/

	private IEnumerator countDown()
	{
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<horMove>().enabled = false;
            players[i].GetComponent<jump>().enabled = false;
            players[i].GetComponentInChildren<WeaponScript>().enabled = false;
        }
		yield return new WaitForSeconds (4);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<horMove>().enabled = true;
            players[i].GetComponent<jump>().enabled = true;
            players[i].GetComponentInChildren<WeaponScript>().enabled = true;
        }
        countDownFinished = true;
	}
}
