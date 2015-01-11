using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	//타일 프리팹.
	public GameObject TilePrefabs;
	//플레이어 프리팹.
	public GameObject UserPlayerPrefab;
	public GameObject AIPlayerPrefab;

	//카드프리팹.
	public GameObject CardPrefab;
	//스킬 토큰.
	public GameObject SkillToken;

	public int mapSize = 10;
	public int deckSize = 40;
	public int cardSize = 5;

	public List<List<Tile>> map =  new List<List<Tile>>();
	public List<Card> handCard = new List<Card> ();
	public List<Player> players = new List<Player>();
	public int currentPlayerIndex = 0;
	public int currentCardIndex = 0;


	//test the Screen world Position;
	//public Transform target;

	Vector3 v3Pos = new Vector3(0, 0, 0);
	//v3Pos = Camera.main.ViewportToWorldPoint(v3Pos);

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		generateMap ();
		Debug.Log ("Generate Map!!" + mapSize);
	
		generatePlayer ();
		Debug.Log ("Generate Players!!");
        //플레이어1 카드생성
		CardManager.instance.generateHandCard(0);
        //플레이어2 카드생성
		CardManager.instance.generateHandCard(1);
		genrateSkillToken ();

        CardManager.instance.player2Camera.camera.enabled = false;
        CardManager.instance.player2Camera.transform.active = false;

		//generateHandCard ();
		//Debug.Log ("Generate HandCrad!!" + cardSize);
		//AudioSource.PlayClipAtPoint( );
	
	}
	
	// Update is called once per frame
	void Update () {

		if (players [currentPlayerIndex].HP > 0)
						players [currentPlayerIndex].TurnUpdate ();
		//players [currentPlayerIndex].TurnUpdate ();
		else {
						nextTurn ();
				}
		//test the Screen world Position;
		//Vector3 screenPos = camera.WorldToScreenPoint(target.position);
		//print("target is " + screenPos.x + " pixels from the left");
	
	}

	void OnGUI(){
		if (players [currentPlayerIndex].HP > 0) {
						players [currentPlayerIndex].TurnOnGUI ();
				}
	}
	/*
void RandomCard()
{
	for(int i =1; i <= 50; i++)
	{
		//int cardNum= rand.Next(50, 0)
	}
}*/

	public void highlightTileAt(Vector2 originLocation, Color highlightColor, int distance){
		List<Tile> highlightedTiles = TileHighlight.FindHighlight (map [(int)originLocation.x] [(int)originLocation.y], distance);

		foreach (Tile t in highlightedTiles) {
			t.transform.renderer.material.color = highlightColor;		
		}
	}


	public void removeTileHighlights()
	{
		for (int i = 0; i < mapSize; i++) {
			for(int j = 0; j<mapSize; j++){
				map[i][j].transform.renderer.material.color = Color.white;
			}
		}
	}

	public void nextTurn()
	{
		if (currentPlayerIndex + 1 < players.Count)
		{
		    currentPlayerIndex++;
            CardManager.instance.player2Camera.camera.enabled = true;
            CardManager.instance.player2Camera.transform.active = true;
            CardManager.instance.player1Camera.camera.enabled = false;
            CardManager.instance.player1Camera.transform.active = false;

		} 
		else
		{
			currentPlayerIndex = 0;
            CardManager.instance.player1Camera.camera.enabled = true;
            CardManager.instance.player1Camera.transform.active = true;
            CardManager.instance.player2Camera.camera.enabled = false;
            CardManager.instance.player2Camera.transform.active = false;
		}
	}

	public void moveCurrentPlayer(Tile destTile)
	{
		if (destTile.transform.renderer.material.color != Color.white) {
						removeTileHighlights ();
						//players [currentPlayerIndex].moving = false;
						players [currentPlayerIndex].gridPosition = destTile.gridPosition;
						players [currentPlayerIndex].moveDestination = destTile.transform.position + 0.5f * Vector3.up;
				} else {
			Debug.Log("destination invalid");
				}
	}

	public void attackWithCurrentPlayer(Tile destTile)
	{
		Player target = null;
		foreach (Player p in players) {
			if(p.gridPosition == destTile.gridPosition)
			{
				target = p;
			}
				}

		if (target != null) {
			if (players [currentPlayerIndex].gridPosition.x >= target.gridPosition.x + 1 &&
				players [currentPlayerIndex].gridPosition.y <= target.gridPosition.y + 1)
			{
				players [currentPlayerIndex].actionPoints--;
				bool hit = Random.Range (0.0f, 1.0f) <= players [currentPlayerIndex].attackChance;
				if (hit)
				{									
					int amountOfDamage = (int)Mathf.Floor (players [currentPlayerIndex].damageBase + Random.Range (0, players [currentPlayerIndex].damageRollSides));
					target.HP -= amountOfDamage;			
					Debug.Log (players [currentPlayerIndex].playerName + "succesfuly hit" + target.playerName + "for" + amountOfDamage + "Damage!");
				} else {
					Debug.Log (players [currentPlayerIndex].playerName + "missed" + target.playerName + "!");
				}
			}
			else 
			{
					Debug.Log ("Target is not adjacent!");
			}
		} 
		else 
		{
			Debug.Log("destination invalid");
		}
		 
	}

	void generateMap()
	{
		map = new List<List<Tile>> ();
		for (int i = 0; i < mapSize; i++) {
			List<Tile> row = new List<Tile>();
			for(int j = 0; j< mapSize; j++){
				Tile tile = ((GameObject)Instantiate(TilePrefabs, new Vector3( i- Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
			
				tile.gridPosition = new Vector2(i,j);
				row.Add(tile);
			}
			map.Add(row);

		}
	}
	/*
	void generateHandCard()
	{
		v3Pos = Camera.main.ScreenToWorldPoint (v3Pos);
		v3Pos.x = v3Pos.x - 2.3f;
		v3Pos.y = v3Pos.y - 2.374634f;
		v3Pos.z = v3Pos.z + 4.61132f;
		string cardName;
		players [0].AddtheDeck ();
		players [0].ShuffleDeck ();
		players [1].AddtheDeck ();
		players [1].ShuffleDeck ();


		handCard = new List<Card> ();
		//for (int h = 0; h<5; h++) {
			
			for (int i = 0; i< cardSize; i++)
			{

				cardName =  players[0].sDeck.Pop();
				if(cardName == "Move1")
				{
					Card card = ((GameObject)Instantiate (Move1, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}

				if(cardName == "Move2")
				{
					Card card = ((GameObject)Instantiate (Move2, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}

				if(cardName == "SDAttack")
				{
					Card card = ((GameObject)Instantiate (SDAttack, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}

				if(cardName = "MDAttack")
				{
					Card card = ((GameObject)Instantiate (SDAttack, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}

				if(cardName == "LDAttack")
				{
					Card card = ((GameObject)Instantiate (LDAttack, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}
				if(cardName == "Critical")
				{
				Card card = ((GameObject)Instantiate (Critical, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}
				if(cardName == "Defense")
				{
					Card card = ((GameObject)Instantiate (Defense, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
					card.gridPosition = new Vector2 (i, 0);
					card.cardNumIndex = i;
					handCard.Add (card);
				}

				//Card card = ((GameObject)Instantiate(CardPrefab, new Vector3( i-Mathf.Floor(cardSize/2), 5.5f, 0), Quaternion.Euler(new Vector3(30, 0)))).GetComponent<Card>();
			/*
			Card card = ((GameObject)Instantiate (CardPrefab, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
			card.gridPosition = new Vector2 (i, 0);
			card.cardNumIndex = i;
			handCard.Add (card);

			//Camera.main.ScreenToWorldPoint(transform
			}
				
		//}

	}
	*/
	/*
	void RandomCard()
	{
	}
	void ExportCard()
	{
	}

	void ExitTurn()
	{
	}

	*/

	void generatePlayer()
	{
		UserPlayer player;

		player = ((GameObject)Instantiate (UserPlayerPrefab, new Vector3 ((mapSize-5) - Mathf.Floor (mapSize / 2), 0.5f, -(mapSize-1) + Mathf.Floor (mapSize / 2)), Quaternion.Euler (new Vector3 ()))).GetComponent<UserPlayer> ();
		//player.gridPosition = new Vector2 (5, 9);
		player.gridPosition = new Vector2 (15, 19);
		player.playerName = "duel";
		//player.AddtheDeck ();
		//player.ShuffleDeck ();
		players.Add (player);

		//player = ((GameObject)Instantiate (UserPlayerPrefab, new Vector3 ((mapSize-5) - Mathf.Floor (mapSize / 2), 0.5f, -(mapSize-1) + Mathf.Floor (mapSize / 2)), Quaternion.Euler (new Vector3 ()))).GetComponent<UserPlayer> ();

		//players.Add (player);

		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(4 - Mathf.Floor(mapSize/2),0.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		player.gridPosition = new Vector2(4,4);
		player.playerName = "Lars";
		//player.AddtheDeck ();
		//player.ShuffleDeck ();
		players.Add (player);

		//AIPlayer aiplayer = ((GameObject)Instantiate (AIPlayerPrefab, new Vector3 (5 - Mathf.Floor (mapSize / 2), 0.5f, -0 + Mathf.Floor (mapSize / 2)), Quaternion.Euler (new Vector3 ()))).GetComponent<AIPlayer> ();
		//aiplayer.gridPosition = new Vector2 (5, 0);
		//aiplayer.playerName = "Black";
		//players.Add (aiplayer);



	}


	void genrateSkillToken ()
	{

	}
}




