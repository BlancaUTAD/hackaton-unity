using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlFlowScenes : MonoBehaviour {

	private bool existLevel;

	void Start () 
	{
		existLevel = false;
		loadSceneRandom ();
	}

	public void loadSceneRandom ()
	{
		int random = Random.Range(1,1);

		if (existLevel) 
			SceneManager.UnloadSceneAsync (2);

		if (random == 1) 
		{
			SceneManager.LoadScene ("Scene2", LoadSceneMode.Additive);
			existLevel = true;
		}
	}
}
