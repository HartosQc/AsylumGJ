using UnityEngine;
using System.Collections;

public class ScaleBox : ScaryEvent {

	Vector3 minScale = new Vector3 (0.1f, 0.1f, 0.1f);
	Vector3 maxScale = new Vector3 (1f, 1f, 1f);
	float scaleTime = .1f;
	GameObject box; 
	bool isScalingDown = false;
	bool isScalingUp = false;

	bool audioFadeIn = false;

	public Light[] lightTab;
	public GameObject[] audioObjects;
	LightFadeInOut lightFadeInOut;
	// Use this for initialization
	void Start () {
		box = GameObject.FindGameObjectWithTag ("Box");
		lightFadeInOut = GetComponent<LightFadeInOut> ();
		setAudio(false);
		//EventStart ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown (KeyCode.M)) {
			EventOver ();
		}

		if (isScalingDown) {
			scalingDown ();
			foreach (Light light in lightTab)
			{
				lightFadeInOut.fadeOut(light,1.3f);
			}
		}

		if (isScalingUp) 
		{
			
			foreach (Light light in lightTab)
			{
				lightFadeInOut.fadeIn(light);
			}
			if (scalingUp ()) 
			{
				destroyEvent ();			
			}
		}

		if (audioFadeIn) 
		{
			fadeAudio ();
		}
	}

	void scalingDown()
	{
		
		box.transform.localScale = Vector3.Lerp (box.transform.localScale, minScale, scaleTime * Time.deltaTime);
		if (box.transform.localScale.x <= minScale.x + 0.01) 
		{
			if (fadeAudio ()) {
				isScalingDown = false;
			}

		}
	}
	 bool scalingUp()
	{
		box.transform.localScale = Vector3.Lerp (box.transform.localScale, maxScale, (scaleTime*2) * Time.deltaTime);

		if (box.transform.localScale.x >= (maxScale.x - 0.001f)) {
			if (fadeAudio ()) {
				isScalingUp = false;
				return true; //Scaling Up over
			}
		}
		return false;
	}

	public override void playEvent()
	{
		setAudio(true);
		isScalingDown = true;
		isScalingUp = false;
	}

	public void EventOver()
	{
		setAudio(true);

		isScalingDown = false;
		isScalingUp = true;
	}

	public override void destroyEvent()
	{
		base.destroyEvent ();
			Debug.Log ("Wall Event Over... Destroy");
			box.transform.localScale = maxScale;
			Destroy (this.gameObject);
		
	}

	void setAudio(bool _value)
	{
		foreach (GameObject sound in audioObjects) {
			sound.GetComponent<AudioSource> ().volume = 0.75f;
			sound.SetActive (_value);
		}
	}

	bool fadeAudio()
	{
		foreach (GameObject sound in audioObjects) {
			sound.GetComponent<AudioSource> ().volume -=Time.deltaTime;

			if (sound.GetComponent<AudioSource> ().volume <= 0) {
				audioFadeIn = false;
				//sound.GetComponent<AudioSource> ().volume = 0.75f;
				setAudio (false);
				return true; //Fade Complete 
			}
		}
		return false;

	}
}
