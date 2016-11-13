﻿using UnityEngine;
using System.Collections;

public class babyEvent : MonoBehaviour {

	bool eventStart = false;
	bool eventOver = false;
	InstanciateRnd instantiateRnd;
	slideBack slide;
	// Use this for initialization
	void Start () 
	{
		instantiateRnd = GetComponent<InstanciateRnd> ();
		slide = GetComponent<slideBack> ();
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
	}

	void EventStart()
	{
		eventStart = true;	
	}

	void EventOver()
	{
		eventStart = false;
		eventOver = true;
	}

	void EventDestroy()
	{
		Destroy (this.gameObject);
	}

}
