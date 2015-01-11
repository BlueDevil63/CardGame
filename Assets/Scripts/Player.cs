using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;


	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	//public int movementPerActionPoint = 5;
	//public int attackRange = 1;

	//public bool moving = false;
	//public bool attacking  = false;


	//캐릭터 스테이터스.
	public string playerName = "Geoge";
	public int HP = 50;

	public float attackChance = 0.75f;
	public float defenseReduction = 0.15f;
	public int damageBase = 5;
	public float damageRollSides = 6;
	
	public int actionPoints = 2;


	//카드 정보.
	public List<string> deck = new List<string>();
	public Stack<string> sDeck = new Stack<string>();

	void Awake()
	{
		moveDestination = transform.position;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void TurnUpdate()
	{
		if (actionPoints <= 0) {
			actionPoints =2;
			//moving = false;
			//attacking = false;
			GameManager.instance.nextTurn();
		}
	}

	public virtual void TurnOnGUI()
	{
	}

	public void AddtheDeck()
	{
		for (int i =0; i<= 40; i++)
		{
			if(i<=8)
			{	deck.Add ("Move1");}
			else if(i <= 13)
			{  	deck.Add ("Move2"); }
			else if(i<= 21)
			{   deck.Add ("SDAttack"); }
			else if(i<= 26)
			{   deck.Add ("LDAttack"); }
			else if(i<= 34)
			{   deck.Add ("Critical"); }
			else if(i<= 40)
			{   deck.Add ("Defense"); }
			
		}
	 
	}

	public void ShuffleDeck()
	{
		for (int i = 0; i<deck.Count; i++) 
		{
			string temp = deck[i];
			int randomIndex = Random.Range(i, deck.Count);
			deck[i] = deck[randomIndex];
			deck[randomIndex] = temp;
			//Debug.Log( randomIndex + "번째는" + i +"번째에 넣는다.");
		}

		for (int i = 0; i<deck.Count; i++) {
			sDeck.Push(deck[i]);

		}
	}
	/*

	*/
}
