using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

	public enum PCard { MOVE1, 
						MOVE2,
						MOVE3,
						SD_ATTACK,
						MD_ATTACK,
						LD_ATTACK,
						CRITICAL,
						DEFENSE,
						SPECIAL
						};
	public int cardNumIndex = 0;
	//hand위치.
	public Vector2 gridPosition = Vector2.zero;
	//비용.
	public int cost;
	//소비 액션 포인트.
	public int actionPoint;
	//카드 속성.
	public PCard property;

	//Raycast

	//public enum 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	public void MouseDown()
	{ 
		if (Input.GetMouseButton (0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 mouseclick = Input.mousePosition;
			Debug.Log( "마우스 위치" + mouseclick.x + "," + mouseclick.y +"," + mouseclick.z);

			if (Physics.Raycast (ray.origin, ray.direction, out hit, 10)) 
			{
				Transform objecthit = hit.transform;
				Debug.Log ("hit");
				if (hit.transform.gameObject.tag == "CARD")
				//if(gameObject.CompareTag("CARD"))
				{
					Debug.Log ("Click The Card!!");
					//CardManager.instance.ActionSelect(property);
					CardAction();
					Game_Manager.instance.currentCardIndex = cardNumIndex;
					//Game_Manager.instance.handCard[Game_Manager.instance.cardSize]
				}
			}
		}

	
	
	}*/

	public virtual void CardAction()
	{
	}





}
