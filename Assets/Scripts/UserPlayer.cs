using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UserPlayer : Player {


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		//if (GameManager.instance.players [GameManager.instance.currentPlayerIndex] == this) {
		if(GameManager.instance.players[GameManager.instance.currentPlayerIndex] == this){
						transform.renderer.material.color = Color.green;
				} else {
			transform.renderer.material.color = Color.white;
				}
		if (HP <= 0) {
			transform.rotation = Quaternion.Euler(new Vector3 (90,0,0));
			transform.renderer.material.color = Color.red;
				}
	
	}

	public override void TurnUpdate()
	{
		if (Vector3.Distance (moveDestination, transform.position) > 0.1f) {
			transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;

			if(Vector3.Distance(moveDestination, transform.position) <= 0.1f){
				transform.position = moveDestination;
				//Game_Manager.instance.nextTurn();
				actionPoints--;
			}
		}
		base.TurnUpdate ();
	}


public override void TurnOnGUI(){
	float buttonHeight =30;
	float buttonWidth = 120;

	Rect buttonRect = new Rect(0, Screen.height - buttonHeight * 3, buttonWidth, buttonHeight);

		/*
	if(GUI.Button(buttonRect, "Move"))
	{
		if(!moving)
		{
			GameManager.instance.removeTileHighlights();
			moving = true;
			attacking = false;
			GameManager.instance.highlightTileAt(gridPosition, Color.blue, movementPerActionPoint);

		}
		else {
			//moving = false;
			attacking = false;
			GameManager.instance.removeTileHighlights();

		}
	}
		*/
		/*
	buttonRect = new Rect(0, Screen.height - buttonHeight * 2, buttonWidth, buttonHeight);

	if(GUI.Button(buttonRect, "Attack"))
	{
		if(!attacking)
		{
			GameManager.instance.removeTileHighlights();
			//moving = false;
			attacking =true;
			GameManager.instance.highlightTileAt(gridPosition, Color.red, attackRange);

		}
		else{
			//moving = false;
			attacking = false;
			GameManager.instance.removeTileHighlights();
		}
	}

		*/
	buttonRect = new Rect(0, Screen.height - buttonHeight * 1, buttonWidth, buttonHeight);

	if(GUI.Button(buttonRect, "End Turn"))
	{
		GameManager.instance.removeTileHighlights();
		actionPoints =2;
		//moving =false;
		//attacking = false;
        CardManager.instance.nextTurn(GameManager.instance.currentPlayerIndex);
		GameManager.instance.nextTurn();

	}

	base.TurnOnGUI();
}
}