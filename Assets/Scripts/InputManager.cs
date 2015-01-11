using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static InputManager instance;
    public Camera player1Camera;
    public Camera player2Camera;
    public Transform target = null;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        MouseDown();
    }
	public void MouseDown()
	{ 
		if (Input.GetMouseButton (0)) 
		{
			RaycastHit hit;
		   // Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Ray ray;
            if (GameManager.instance.currentPlayerIndex == 0)
            {
                ray = player1Camera.ScreenPointToRay(Input.mousePosition);
            }
            else if (GameManager.instance.currentPlayerIndex == 1)
            {
                ray = player2Camera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
			Vector3 mouseclick = Input.mousePosition;
			//Debug.Log( "마우스 위치" + mouseclick.x + "," + mouseclick.y +"," + mouseclick.z);
			
			if (Physics.Raycast (ray.origin, ray.direction, out hit, 10)) 
			{
				Transform objecthit = hit.transform;
				Debug.Log ("hit");
				if (hit.transform.gameObject.tag== "CARD")
				{
                    target = hit.transform;
                   // Debug.Log(target.GetComponent<MoveCard1>().cardNumIndex);
					//Debug.Log ("Click The Card!!" + hit.transform.gameObject.name);
					CardManager.instance.cardAction(hit.transform.gameObject.name);

				}

			}
		}	
		
	}

    public void KeyDown()
    {

    }



	
}
