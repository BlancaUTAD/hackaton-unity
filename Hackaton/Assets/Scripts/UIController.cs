using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private Canvas myCanvas;
	private Scrollbar staminaBarPlayer1;
	private Scrollbar staminaBarPlayer2;
	private GameController currentGameController;

	void Awake () 
	{
		myCanvas = GameObject.Find("CanvasGame").GetComponent<Canvas>();
		staminaBarPlayer1 = myCanvas.transform.Find ("StaminaPlayer1").GetComponent<Scrollbar> ();
		staminaBarPlayer2 = myCanvas.transform.Find ("StaminaPlayer2").GetComponent<Scrollbar> ();
		myCanvas.enabled = false;
	}

	void Update () 
	{
		if (currentGameController != null) 
		{
			staminaBarPlayer1.size = (currentGameController.staminaPlayer1 / 100);
			staminaBarPlayer2.size = (currentGameController.staminaPlayer2 / 100);
		} 
	}

	public void enableCanvas()
	{
		myCanvas.enabled = true;
	}

	public void setCurrentGameController(GameController gc)
	{
		currentGameController = gc;
	}
}
