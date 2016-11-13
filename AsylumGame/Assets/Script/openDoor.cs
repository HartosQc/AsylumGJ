using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	bool playerInSight = false;
	GameObject player;
	public GameObject money;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		money.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerInSight) 
		{
			inSight ();
		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			playerInSight = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") 
		{
			playerInSight = false;
		}
	}

	void inSight()
	{
		
		Ray ray = new Ray(player.transform.position, transform.forward);
		Debug.DrawRay (player.transform.position, player.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100)){

			money.SetActive (true);
			
		}
	}
}
