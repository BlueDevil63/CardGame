using UnityEngine;
using System.Collections;

public class SDAttackCard :Card {
	//public new int cardCost = 100;
	//public new int cardAction = 1;
	//public new PCard cardProperty = PCard.SD_ATTACK;
	public int attackRange = 2;
	//public new int cost = 100;
	//public new int actionPoint = 1;
	//public new  PCard property = PCard.SD_ATTACK;
	
	// Use this for initialization
	void Start () {
	 
		cost = 100;
		actionPoint = 1;
		property = PCard.SD_ATTACK;

	}
	
	// Update is called once per frame
	void Update () {
		//OnMouseDown ();
	}
	public override void CardAction()
	{
		Debug.Log("you click the SDAttack 1 Card = (" + gridPosition + ")");
		GameManager.instance.removeTileHighlights();
		GameManager.instance.highlightTileAt(GameManager.instance.players[GameManager.instance.currentPlayerIndex].gridPosition, Color.red, attackRange);
	}




}
