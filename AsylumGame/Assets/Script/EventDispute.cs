using UnityEngine;
using System.Collections;

public class EventDispute : ScaryEvent {

	bool eventIsStarted = false;
	bool eventIsOver = false;
	public GameObject disputeAudio;
	public GameObject hearth;

	slideBack slide;
	// Use this for initialization
	void Start () 
	{
		slide = GetComponent<slideBack> ();
		disputeAudio.SetActive (false);
		//playEvent();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (disputeAudio.GetComponent<AudioSource>().time > 47f)
		{
			EventOver ();
		}

		if (eventIsStarted) {
			slide.slideUp ();
		}

		if (eventIsOver) {
			if (slide.slideDown () && !disputeAudio.GetComponent<AudioSource>().isPlaying) {
				destroyEvent ();
			}	
		}	
	}

	public override void playEvent()
	{
		hearth.SetActive (true);
		disputeAudio.SetActive (true);
		eventIsStarted = true;
		eventIsOver = false;
	}

	public void EventOver()
	{
		eventIsOver = true;
		eventIsStarted = false;

	}

	public override void destroyEvent()
	{
		base.destroyEvent ();
		Debug.Log ("Dispute Event Destroy");
		Destroy (this.gameObject);

	}
}
