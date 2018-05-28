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
			SceneManager.UnloadSceneAsync (5);

		if (random == 1) 
		{
			SceneManager.LoadScene ("Scene5", LoadSceneMode.Additive);
			existLevel = true;
		}
	}
}
