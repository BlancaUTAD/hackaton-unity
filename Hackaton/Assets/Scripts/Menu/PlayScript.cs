using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	public void QuitGame ()
	{
		Debug.Log ("I am quitting");
		Application.Quit ();
	}

}
