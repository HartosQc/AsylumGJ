using UnityEngine;
using System.Collections;

public class EventDispute : MonoBehaviour {

	bool eventIsStarted = false;
	bool eventIsOver = false;

	public GameObject hearth;

	slideBack slide;
	// Use this for initialization
	void Start () 
	{
		slide = GetComponent<slideBack> ();
		EventStart();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (eventIsStarted) {
			slide.slideUp ();
		}

		if (eventIsOver) {
			if (slide.slideDown ()) {
				EventDestroy ();
			}	
		}	
	}

	public void EventStart()
	{
		hearth.SetActive (true);
		eventIsStarted = true;
		eventIsOver = false;
	}

	public void EventOver()
	{
		eventIsOver = true;
		eventIsStarted = false;

	}

	void EventDestroy()
	{
		Destroy (this.gameObject);
	}
}
