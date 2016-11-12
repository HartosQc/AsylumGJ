﻿using UnityEngine;
using System.Collections;

public class LightFadeInOut : MonoBehaviour {

	public Light[] lightTab;
	public Light pointLight;
	float fadeTime = .7f;
	bool fadingOut = false;
	bool fadingIn = false;
	private float mEndTime = 0;
	private float mStartTime = 0;

	const float LIGHT_INTENSITY = 3.2f; 
	// Use this for initialization
	void Start () 
	{
		//pointLight.enabled = false;

	}


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.O)) {
			fadingOut = true;
			fadingIn = false;
			//pointLight.enabled = true;
		}

		if (Input.GetKeyDown (KeyCode.I)) {
		
			fadingIn = true;
			fadingOut = false;
			//pointLight.enabled = false;
		}

		if (fadingOut) {
			foreach (Light light in lightTab) {
				fadeOut (light);
			}
			fadeIn (pointLight);
		}

		if (fadingIn) {
			foreach (Light light in lightTab) {
				fadeIn (light);
			}
			fadeOut (pointLight);
		}

		Debug.Log ("Fading Out:" + fadingOut);
		Debug.Log ("Fading In: " + fadingIn);
	}

	public void fadeIn(Light light)
	{
		//foreach (Light light in lightTab)
		//{

			light.intensity = Mathf.Lerp(light.intensity,LIGHT_INTENSITY,fadeTime * Time.deltaTime);

			if (light.intensity >= LIGHT_INTENSITY) {
				fadingIn = false;
			}
		//}
	}

	public void fadeOut(Light light)
	{
		//foreach (Light light in lightTab)
		//{
			light.intensity = Mathf.Lerp(light.intensity,0,fadeTime * Time.deltaTime);

			
			if (light.intensity <= 0.009) {
				fadingOut = false;
			}
		//}



	}
}
