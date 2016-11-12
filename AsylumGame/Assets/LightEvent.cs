using UnityEngine;
using System.Collections;

public class LightEvent : MonoBehaviour {

	// Use this for initialization
	LightFadeInOut lightFadeInOut;
	public Light[] lightTab;
	public Light pointLight;

	bool eventIsStarted = false;
	bool eventIsOver = false;
	void Start () 
	{
		lightFadeInOut = GetComponent<LightFadeInOut> ();
		EventStart ();
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
					EventDestroy ();
				}
			}
			lightFadeInOut.fadeOut (pointLight,0f);
		}
	

		//DEBUG
		if (Input.GetKeyDown (KeyCode.I)) {

			EventOver ();
		}
	}

	public void EventStart()
	{
		eventIsStarted = true;
	}

	public void EventOver ()
	{
		eventIsStarted = false;
		eventIsOver = true;
	}

	void EventDestroy()
	{
		foreach (Light light in lightTab) {

			light.intensity = 3.2f;
		}
		Debug.Log ("LightEvent Destroy");
		Destroy (this.gameObject);
	}

}
