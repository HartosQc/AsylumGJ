using UnityEngine;
using System.Collections;

public class LightEvent : ScaryEvent {

	// Use this for initialization
	LightFadeInOut lightFadeInOut;
	public Light[] lightTab;
	public Light pointLight;

	public GameObject clipGenerator;
	bool eventIsStarted = false;
	bool eventIsOver = false;
	void Start () 
	{
		lightFadeInOut = GetComponent<LightFadeInOut> ();
		clipGenerator.SetActive (false);
		//playEvent ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (eventIsStarted) {
			foreach (Light light in lightTab) {
				lightFadeInOut.fadeOut(light,0f);
			}
			lightFadeInOut.fadeIn (pointLight);
		}

		if (eventIsOver) {
			foreach (Light light in lightTab) {
				
				if (lightFadeInOut.fadeIn (light)) {
					destroyEvent ();
				}
			}
			lightFadeInOut.fadeOut (pointLight,0f);
		}
	

		//DEBUG
		if (Input.GetKeyDown (KeyCode.I)) {

			EventOver ();
		}
	}

	public override void playEvent()
	{
		eventIsStarted = true;
		clipGenerator.SetActive (true);
	}

	public void EventOver ()
	{
		eventIsStarted = false;
		eventIsOver = true;
		clipGenerator.SetActive (false);
	}

	public override void destroyEvent()
	{
		foreach (Light light in lightTab) {

			light.intensity = 3.2f;
		}
		Debug.Log ("LightEvent Destroy");
		base.destroyEvent ();
		Destroy (this.gameObject);
	}

}
