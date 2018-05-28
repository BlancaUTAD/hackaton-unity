using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlFlowScenes : MonoBehaviour {

	private int currentLevel;
    private List<int> previousLevels;
    private int random;

	void Start () 
	{
        currentLevel = -1;
        previousLevels = new List<int>();
        loadSceneRandom ();

    }

    public void loadSceneRandom()
    {
        if (previousLevels.Count < 5)
        {
            if (currentLevel > 0)
            {
                bool existLevel = true;
                while (existLevel)
                {
                    random = Random.Range(1, 6);
                    existLevel = false;
                    Debug.Log("previousLevels: " + previousLevels);
                    for (int i = 0; i < previousLevels.Count; i++)
                    {
                        if (previousLevels[i] == random)
                        {
                            existLevel = true;
                        }
                    }
                }
            }
            else
            {
                random = Random.Range(1, 6);
            }

            if (currentLevel > 0)
                SceneManager.UnloadSceneAsync(currentLevel);

            if (random == 1)
            {
                SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
            }
            else if (random == 2)
            {
                SceneManager.LoadScene("Scene2", LoadSceneMode.Additive);
            }
            else if (random == 3)
            {
                SceneManager.LoadScene("Scene3", LoadSceneMode.Additive);
            }
            else if (random == 4)
            {
                SceneManager.LoadScene("Scene4", LoadSceneMode.Additive);
            }
            else if (random == 5)
            {
                SceneManager.LoadScene("Scene5", LoadSceneMode.Additive);
            }
            currentLevel = random;
            previousLevels.Add(currentLevel);
        }
    }
}
