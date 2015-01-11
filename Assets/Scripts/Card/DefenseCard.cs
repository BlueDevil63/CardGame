using UnityEngine;
using System.Collections;

public class DefenseCard : Card {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//OnMouseDown ();
	
	}
	public override void CardAction()
	{
		Debug.Log("you click the CriticalCard = (" + gridPosition + ")");
		//Game_Manager.instance.removeTileHighlights();
		//Game_Manager.instance.highlightTileAt(Game_Manager.instance.players[Game_Manager.instance.currentPlayerIndex].gridPosition, Color.red, attackRange);
		Destroy(CardManager.instance.handCard[CardManager.instance.currentCardIndex].gameObject);
	}
}
