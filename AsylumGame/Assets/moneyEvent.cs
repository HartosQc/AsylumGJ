using UnityEngine;
using System.Collections;

public class moneyEvent : MonoBehaviour {

	public GameObject door;


	// Use this for initialization
	void Start () 
	{
		door.SetActive(false);
		//startEvent ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void startEvent()
	{
		door.SetActive(true);
	}

	public void destroyEvent()
	{
		Destroy (this.gameObject);
	}
}
