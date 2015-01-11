using UnityEngine;
using System.Collections;

public class CriticalCard : Card {
	public int attackRange = 1;

	// Use this for initialization
	void Start () {

		cost = 100;
		actionPoint = 2;
		property = PCard.SD_ATTACK;
	
	}
	
	// Update is called once per frame
	void Update () {
		//OnMouseDown ();
	
	}

	public override void CardAction()
	{
		Debug.Log("you click the CriticalCard = (" + gridPosition + ")");
		GameManager.instance.removeTileHighlights();
		GameManager.instance.highlightTileAt(GameManager.instance.players[GameManager.instance.currentPlayerIndex].gridPosition, Color.red, attackRange);
	}
}
