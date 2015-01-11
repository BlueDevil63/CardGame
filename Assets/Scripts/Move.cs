using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed = 2.0f;
	public GameObject player;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		target = transform.position;
		//player.transform.position.x = 0.5f;
		//player.transform.position.y = 0.5f;
		//player.transform.position.z = -4.5f;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//target.z = transform.position.z;
			//target.x = transform.position.x;
			target.x = Input.mousePosition.x;
			target.y = Input.mousePosition.y;

		}
		//transform.position = Vector3.MoveTowards (transform.position, target, speed*Time.deltaTime
		 //                                        );
		//player.transform.position = Vector3.MoveTowards (transform.position, target, speed*Time.deltaTime);

		transform.position = target;
	
	}
}
