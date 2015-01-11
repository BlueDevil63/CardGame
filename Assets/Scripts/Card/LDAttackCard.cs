using UnityEngine;
using System.Collections;

public class LDAttackCard : Card {
	public int attackRange = 5;
	//public new int cost = 100;
	//public new int actionPoint = 1;
	//public new  PCard property = PCard.LD_ATTACK;

	// Use this for initialization
	void Start () {

	 	cost = 100;
		actionPoint = 1;
		property = PCard.LD_ATTACK;
	
	}
	
	// Update is called once per frame
	void Update () {
	//	OnMouseDown ();
	}
	public override void CardAction()
	{
		Debug.Log("you click the LDAttack 1 Card = (" + gridPosition + ")");
		GameManager.instance.removeTileHighlights();
		GameManager.instance.highlightTileAt(GameManager.instance.players[GameManager.instance.currentPlayerIndex].gridPosition, Color.red, attackRange);
	}

}
