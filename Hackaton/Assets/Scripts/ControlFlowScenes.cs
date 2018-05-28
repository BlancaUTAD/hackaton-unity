﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ControlFlowScenes : MonoBehaviour {

	private int currentLevel;
    private List<int> previousLevels;
    private int random;
    private float currentTimeScale;
    public Text myText;
    public Text textContPlayer1;
    public Text textContPlayer2;
    private int contPlayer1;
    private int contPlayer2;

    void Start () 
	{
        currentLevel = -1;
        previousLevels = new List<int>();
        contPlayer1 = 0;
        contPlayer2 = 0;
        loadSceneRandom (0);

    }

    public void loadSceneRandom(int winner)
    {
        if (winner == 1)
        {
            contPlayer1++;
        }
        else if (winner == 2)
        {
            contPlayer2++;
        }

        textContPlayer1.text = contPlayer1.ToString();
        textContPlayer2.text = contPlayer2.ToString();

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
            {
                Debug.Log("currentLevel: " + currentLevel);
                SceneManager.UnloadSceneAsync(currentLevel);
            }

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
            StartCoroutine(countDown());
        }

        else
        {
            SceneManager.UnloadSceneAsync(currentLevel);
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
            myText.fontSize = 50;
            if (contPlayer1 > contPlayer2)
            {
                myText.text = "Winner player 1";
            }
            else if (contPlayer1 < contPlayer2)
            {
                myText.text = "Winner player 2";
            }
            else
            {
                myText.text = "Tie";
            }
        }
    }

    private IEnumerator countDown()
    {
        Debug.Log("Entro");
        yield return new WaitForSeconds(1);
        myText.text = "3";
        yield return new WaitForSeconds(1);
        myText.text = "2";
        yield return new WaitForSeconds(1);
        myText.text = "1";
        yield return new WaitForSeconds(1);
        myText.text = "GO";
        yield return new WaitForSeconds(1);
        myText.text = "";
    }
}
