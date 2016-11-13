using UnityEngine;
using System.Collections;

public class babyEvent : MonoBehaviour {

	public GameObject babyNormal;

	bool eventStart = false;
	bool eventOver = false;
	slideBack slide;
	// Use this for initialization
	void Start () 
	{
		
		slide = GetComponent<slideBack> ();
		EventStart ();
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
				EventDestroy ();
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

	void EventStart()
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

	void EventDestroy()
	{
		Destroy (this.gameObject);
	}

}
