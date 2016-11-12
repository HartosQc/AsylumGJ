using UnityEngine;
using System.Collections;

public class ScaleBox : MonoBehaviour {

	Vector3 minScale = new Vector3 (0.1f, 0.1f, 0.1f);
	Vector3 maxScale = new Vector3 (1f, 1f, 1f);
	float scaleTime = .1f;
	public GameObject box; 
	bool isScalingDown = false;
	bool isScalingUp = false;


	public Light[] lightTab;

	LightFadeInOut lightFadeInOut;
	// Use this for initialization
	void Start () {
		box = GameObject.FindGameObjectWithTag ("Box");
		lightFadeInOut = GameObject.FindWithTag ("GameMaster").GetComponent<LightFadeInOut> ();
		lightTab = lightFadeInOut.lightTab;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.N)) {
			isScalingDown = true;
			isScalingUp = false;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			isScalingDown = false;
			isScalingUp = true;
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
			scalingUp ();
			foreach (Light light in lightTab)
			{
				lightFadeInOut.fadeIn(light);
			}
		}
	}

	void scalingDown()
	{
		
		box.transform.localScale = Vector3.Lerp (box.transform.localScale, minScale, scaleTime * Time.deltaTime);
		if (box.transform.localScale.x <= minScale.x) {
			isScalingDown = false;
		}
	}
	void scalingUp()
	{
		box.transform.localScale = Vector3.Lerp (box.transform.localScale, maxScale, (scaleTime*2) * Time.deltaTime);

		if (box.transform.localScale.x >= maxScale.x) {
			isScalingUp = false;
		}
	}
}
