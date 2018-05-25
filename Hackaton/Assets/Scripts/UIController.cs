using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public Canvas myCanvas;
	public Scrollbar staminaBarPlayer1;
	public Scrollbar staminaBarPlayer2;
	public GameController myGameController;

	void Start () 
	{
		myCanvas = GameObject.Find ("CanvasGame").GetComponent<Canvas>();
		staminaBarPlayer1 = myCanvas.transform.Find ("StaminaPlayer1").GetComponent<Scrollbar> ();
		staminaBarPlayer2 = myCanvas.transform.Find ("StaminaPlayer2").GetComponent<Scrollbar> ();
		myGameController = this.GetComponent<GameController> ();
	}

	void Update () 
	{
		staminaBarPlayer1.size = (myGameController.staminaPlayer1 / 100);
		staminaBarPlayer2.size = (myGameController.staminaPlayer2 / 100);
	}

	public void findCurrentGameController()
	{
		
	}
}
