using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour {
	public static CardManager instance; 

	//카메라.
	public GameObject player1Camera;  
    public GameObject player2Camera;
	//카드 프리팹.
	public GameObject Move1;
	public GameObject Move2;
	public GameObject SDAttack;
	public GameObject LDAttack;
	public GameObject Defense;
	public GameObject Critical;
	public GameObject Special;

	public int deckSize = 40;
	public int cardSize = 5;
	public int nextCard =2;
	public int currentSize = 0;

	//카드 객체 생성.
	MoveCard1 cMove1 = new MoveCard1 ();
	MoveCard2 cMove2 = new MoveCard2 ();
	SDAttackCard cSDAttack = new SDAttackCard ();
	LDAttackCard cLDAtack = new LDAttackCard ();
	CriticalCard cCritical = new CriticalCard ();
	DefenseCard cDefense = new DefenseCard ();


	GameObject gCard;
	public int currentCardIndex = 0;
	public Card.PCard cProperty ;

	public List<Card> handCard = new List<Card> ();
	// Use this for initialization

	
	void Awake()
	{	
        instance = this;
	}
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}



    //손에 있는 카드생성 5장이 될때 까지 반복
	public void generateHandCard(int player)
	{
		string cardName;
		GameManager.instance.players [player].AddtheDeck ();
		GameManager.instance.players [player].ShuffleDeck ();
		//Game_Manager.instance.players [1].AddtheDeck ();
		//Game_Manager.instance.players [1].ShuffleDeck ();

		handCard = new List<Card> ();

					//for (int h = 0; h<5; h++) {
			
		for (int i = 0; i< cardSize; i++) 
		{
			cardName = GameManager.instance.players [0].sDeck.Pop ();
			switch (cardName)
			{
			case "Move1":
				gCard = Move1;
				break;
			case "Move2":
				gCard = Move2;
				break;
			case "SDAttack":
				gCard = SDAttack;
				break;
			case "LDAttack":
				gCard = LDAttack;
				break;
			case "Critical":
				gCard = Critical;
				break;
			case "Defense":
				gCard = Defense;
				break;
			
			}
			generateCard(gCard, i, player);
			currentSize++;

		}

		}

			/*
			if(cardName == "Move1")
			{
				Card card = ((GameObject)Instantiate (Move1, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2), v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
				card.gridPosition = new Vector2 (i, 0);
				card.cardNumIndex = i;
				handCard.Add (card);
			}
			*/

    //카드를 화면에 생성하고 카메라에 붙인다.
	public void generateCard( GameObject cardObject, int i, int player)
	{	
        //+(i*120
		Vector3 v3Pos = new Vector3(Screen.width/10, Screen.height/10, 5.5f);
        if (GameManager.instance.currentPlayerIndex == 0)
        {
            v3Pos = InputManager.instance.player1Camera.ScreenToWorldPoint(v3Pos);
        }
        else if (GameManager.instance.currentPlayerIndex == 1)
        {
            v3Pos = InputManager.instance.player2Camera.ScreenToWorldPoint(v3Pos);
        }
        else
        {
            v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        }
		//v3Pos = Camera.main.ScreenToWorldPoint (v3Pos);
        v3Pos = v3Pos +new Vector3(i * 1, 0, 0);
		Debug.Log(Screen.width+ " , " + Screen.height);


		Card card = ((GameObject)Instantiate (cardObject ,new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
        if (player == 0)
        {
            card.transform.parent = player1Camera.transform;
           // player1Cameras.transform
        }
        else if (player == 1)
        {
            card.transform.parent = player2Camera.transform;
        }
        
		//Card card = ((GameObject)Instantiate (cardObject, new Vector3 (v3Pos.x + i - Mathf.Floor (cardSize / 2) + posx, v3Pos.y, v3Pos.z), Quaternion.Euler (new Vector3 (230, 0, 180)))).GetComponent<Card> ();
		//card = transform.position (10, 10, 10);
		card.transform.position = v3Pos;
		card.gridPosition = new Vector2 (i, 0);
		card.cardNumIndex = i;
		//card.transform.parent = _camera.transform;
		handCard.Add (card);
		//_camera.


	}

		
		
	public void nextTurn(int y)
	{
		string cardName;
		//Game_Manager.instance.players [y].AddtheDeck ();
		//Game_Manager.instance.players [y].ShuffleDeck ();
		//Game_Manager.instance.players [1].AddtheDeck ();
		//Game_Manager.instance.players [1].ShuffleDeck ();
		
		//if (y == 1)
		//	y = Screen.height - v3Pos;
		
		//v3Pos = Camera.main.ScreenToWorldPoint (v3Pos);
		//v3Pos.x = v3Pos.x - 2.3f;
		//v3Pos.y = v3Pos.y - 2.374634f;
		//v3Pos.z = v3Pos.z + 4.61132f;
		
		
		
		handCard = new List<Card> ();
		
		//for (int h = 0; h<5; h++) {
		
		for (int i = 0; i< nextCard; i++) 
		{
			cardName = GameManager.instance.players [0].sDeck.Pop ();
			switch (cardName)
			{
			case "Move1":
				gCard = Move1;
				break;
			case "Move2":
				gCard = Move2;
				break;
			case "SDAttack":
				gCard = SDAttack;
				break;
			case "LDAttack":
				gCard = LDAttack;
				break;
			case "Critical":
				gCard = Critical;
				break;
			case "Defense":
				gCard = Defense;
				break;
				currentSize++;
				
			}
			generateCard(gCard, currentSize, y);
			
		}

	}

	public void cardAction(string cardName)
	{
		switch (cardName)
		{
		case "Move1":
         // Debug.Log(InputManager.instance.target.GetComponent<MoveCard1>().cardNumIndex);            
			cProperty = Card.PCard.MOVE1;
			cMove1.CardAction();
			Debug.Log( cMove1.cardNumIndex);
			break;
		case "Move2":
			cProperty = Card.PCard.MOVE2;
			cMove2.CardAction ();
			break;
		case "SDAttack":
			cProperty = Card.PCard.SD_ATTACK;
			cSDAttack.CardAction ();
			break;
		case "LDAttack":
			cProperty = Card.PCard.LD_ATTACK;
			cLDAtack.CardAction();
			break;
		case "Critical":
			cProperty = Card.PCard.CRITICAL;
			cCritical.CardAction();
			break;
		case "Defense":
			cProperty = Card.PCard.DEFENSE;
			cDefense.CardAction();
			break;

		}

	}
		
}

