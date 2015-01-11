using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCard1 : Card {
	//UserPlayer player;
	public int movementPerActionPoint = 3;


	// Use this for initialization
	//public new int cost = 100;
	//public new int actionPoint = 1;
	//public new  PCard property = PCard.MOVE1;

	public 

	void Start () {
		cost = 100;
		actionPoint = 1;
		property = PCard.MOVE1;
	
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("moveCard update");
		//OnMouseDown ();
	
	}

	public  override void CardAction()
	{
		Debug.Log("you click the move 1 Card = (" + gridPosition + ")");
			GameManager.instance.removeTileHighlights();
			GameManager.instance.highlightTileAt(GameManager.instance.players[GameManager.instance.currentPlayerIndex].gridPosition, Color.blue, movementPerActionPoint);
			if(Input.GetKeyDown (KeyCode.Escape))
			{
				GameManager.instance.removeTileHighlights();
			}
	}

}


