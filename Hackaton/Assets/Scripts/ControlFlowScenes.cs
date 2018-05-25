using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlFlowScenes : MonoBehaviour {

	private bool existLevel;
	private List <GameObject> listGO;

	// Use this for initialization
	void Start () 
	{
		listGO = new List<GameObject> ();
		existLevel = false;
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
			listGO.Clear ();
			listGO.AddRange(SceneManager.GetSceneByName ("Scene1").GetRootGameObjects ());
			existLevel = true;
		}
		this.GetComponent<UIController> ().enableCanvas ();
		for (int i = 0; i < listGO.Count; i++) 
		{
			if (listGO [i].name == "ControllerLevel") 
			{
				this.GetComponent<UIController> ().setCurrentGameController (listGO [i].GetComponent<GameController> ());
				//break;
			}
		}
		
	}
}
