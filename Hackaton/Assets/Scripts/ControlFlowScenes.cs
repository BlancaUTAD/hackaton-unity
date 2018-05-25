using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlFlowScenes : MonoBehaviour {

	bool existLevel;
	// Use this for initialization
	void Start () 
	{
		loadSceneRandom ();
	}

	public void loadSceneRandom ()
	{
		int random = Random.Range(1,1);
		if (existLevel)
			SceneManager.UnloadSceneAsync (1);
		if (random == 1) 
		{
			SceneManager.LoadScene ("Scene1", LoadSceneMode.Additive);
			existLevel = true;
		}
	}
}
