using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile :  MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;

	public int movementCost = 1;
	
	public List<Tile> neighbors = new List<Tile>();


	// Use this for initialization
	void Start () {
		generateNeighbors ();
		Debug.Log ("genrateNeighbors!!");
	
	}

	public void generateNeighbors()
	{
		neighbors = new List<Tile> ();
		//up
		if (gridPosition.y > 0) {
			Vector2 n = new Vector2(gridPosition.x , gridPosition.y -1);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
				}
		//down
		if (gridPosition.y < GameManager.instance.mapSize -1) {
			Vector2 n = new Vector2(gridPosition.x, gridPosition.y +1);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//left
		if (gridPosition.x > 0) {
			Vector2 n = new Vector2(gridPosition.x-1 , gridPosition.y );
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//right
		if (gridPosition.x < GameManager.instance.mapSize -1) {
			Vector2 n = new Vector2(gridPosition.x +1, gridPosition.y );
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}

		}

	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter(){
		/*
		if (Game_Manager.instance.players [Game_Manager.instance.currentPlayerIndex].moving) {
						transform.renderer.material.color = Color.blue;
				} else if (Game_Manager.instance.players [Game_Manager.instance.currentPlayerIndex].attacking) {
			transform.renderer.material.color = Color.red;
		}

	

		//Debug.Log("My Position is(" +gridPosition.x + ","+ gridPosition.y);

*/
	}
	void OnMouseExit(){
			//	transform.renderer.material.color = Color.white;
		}
	void OnMouseDown(){
				/*
		if(Game_Manager.instance.players[Game_Manager.instance.currentPlayerIndex].moving)
		//if (Game_Manager.instance.players [Game_Manager.instance.currentPlayerIndex]) 
		{

				} else if (Game_Manager.instance.players [Game_Manager.instance.currentPlayerIndex].attacking) {
			Game_Manager.instance.attackWithCurrentPlayer(this);
			*/
				
		if (CardManager.instance.cProperty == Card.PCard.MOVE1) 
		{Debug.Log(CardManager.instance.currentCardIndex);
			GameManager.instance.moveCurrentPlayer (this);

			Destroy(CardManager.instance.handCard[CardManager.instance.currentCardIndex].gameObject);
			CardManager.instance.handCard.RemoveAt(CardManager.instance.currentCardIndex);
						//Game_Manager.instance.handCard.RemoveAt (Game_Manager.instance.currentCardIndex);

		}
		if (CardManager.instance.cProperty== Card.PCard.MOVE2)
		{Debug.Log(CardManager.instance.currentCardIndex);
			GameManager.instance.moveCurrentPlayer (this);
			Destroy(CardManager.instance.handCard[CardManager.instance.currentCardIndex].gameObject);
			CardManager.instance.handCard.RemoveAt(CardManager.instance.currentCardIndex);
					//Game_Manager.instance.handCard.RemoveAt (Game_Manager.instance.currentCardIndex);
			
		}
		if (CardManager.instance.cProperty == Card.PCard.SD_ATTACK) 
		{Debug.Log(CardManager.instance.currentCardIndex);
			GameManager.instance.attackWithCurrentPlayer (this);
			Destroy(CardManager.instance.handCard[CardManager.instance.currentCardIndex].gameObject);
			CardManager.instance.handCard.RemoveAt(CardManager.instance.currentCardIndex);
		}

	}
}
