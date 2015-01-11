using UnityEngine;
using System.Collections;

public class MoveCard2 : Card {
	public int movementPerActionPoint =5;

	// Use this for initialization
	void Start () {
		cost = 100;
		actionPoint = 1;
		property = PCard.MOVE2;
	
	}

	void Update () {
		//OnMouseDown ();
	}
	
	// Update is called once per frame
	public  override void CardAction()
	{
		Debug.Log("you click the move 2 Card = (" + gridPosition + ")");
		GameManager.instance.removeTileHighlights();
		//UserPlayer.moving= true;
		//UserPlayer.attacking =false;
		
		GameManager.instance.highlightTileAt(GameManager.instance.players[GameManager.instance.currentPlayerIndex].gridPosition, Color.blue, movementPerActionPoint);
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			GameManager.instance.removeTileHighlights();
		}
		
	}
	
}
