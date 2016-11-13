using UnityEngine;
using System.Collections;

public class moneyEvent : ScaryEvent {

	public GameObject door;



	// Use this for initialization
	void Start () 
	{
		door.SetActive(false);
		//playEvent ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public override void playEvent()
	{
		door.SetActive(true);
	}

	public override void destroyEvent()
	{
		base.destroyEvent ();
		Destroy (this.gameObject);
	}
}
