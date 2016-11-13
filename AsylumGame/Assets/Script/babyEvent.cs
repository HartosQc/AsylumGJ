using UnityEngine;
using System.Collections;

public class babyEvent : ScaryEvent {

	public GameObject babyNormal;
	bool eventStart = false;
	bool eventOver = false;
	slideBack slide;
	// Use this for initialization
	void Start () 
	{
		slide = GetComponent<slideBack> ();
		babyNormal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (eventStart) 
		{
			slide.slideUp ();
		}
		if (eventOver) 
		{
			if (slide.slideDown ()) 
			{
				destroyEvent ();
			}
		}
		if (Input.GetKeyDown (KeyCode.U)) 
		{
			EventOver ();
		}

		if (!babyNormal.GetComponent<AudioSource> ().isPlaying) {
			EventOver ();
		}
	}

	public override void playEvent()
	{
		babyNormal.SetActive (true);
		eventStart = true;	
		eventOver = false;
	}

	void EventOver()
	{
		eventStart = false;
		eventOver = true;

		babyNormal.SetActive (false);
	}

	public override void destroyEvent()
	{
		base.destroyEvent ();
		Destroy (this.gameObject);
	}

}
