using UnityEngine;
using System.Collections;

public class LightFadeInOut : MonoBehaviour {

	//public Light[] lightTab;
	//public Light pointLight;
	float fadeTime = .7f;
	bool fadingOut = false;
	bool fadingIn = false;
	private float mEndTime = 0;
	private float mStartTime = 0;

	const float LIGHT_INTENSITY = 3.3f; 
	// Use this for initialization
	void Start () 
	{
		//pointLight.enabled = false;

	}


	// Update is called once per frame
	void Update () 
	{
			
	}

	public bool fadeIn(Light light)
	{
		light.intensity = Mathf.Lerp(light.intensity,LIGHT_INTENSITY,fadeTime * Time.deltaTime);

		if (light.intensity >= (LIGHT_INTENSITY * .95f)) {
				fadingIn = false;
			return true;//Light at max intensity
			}

		return false;
	}

	public void fadeOut(Light light, float targetIntensity)
	{

		light.intensity = Mathf.Lerp(light.intensity,(targetIntensity-0.1f),fadeTime * Time.deltaTime);

			
		if (light.intensity < targetIntensity) {
			light.intensity = targetIntensity;
				fadingOut = false;
			}
	}
}
