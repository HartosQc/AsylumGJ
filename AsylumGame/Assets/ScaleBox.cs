using UnityEngine;
using System.Collections;

public class ScaleBox : MonoBehaviour {

	Vector3 minScale = new Vector3 (0.1f, 0.1f, 0.1f);
	Vector3 maxScale = new Vector3 (1f, 1f, 1f);
	float scaleTime = .1f;
	GameObject box; 
	bool isScalingDown = false;
	bool isScalingUp = false;

	public Light[] lightTab;

	LightFadeInOut lightFadeInOut;
	// Use this for initialization
	void Start () {
		box = GameObject.FindGameObjectWithTag ("Box");
		lightFadeInOut = GetComponent<LightFadeInOut> ();
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
			if (scalingUp ()) {
				EventDestroy ();
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
	 bool scalingUp()
	{
		box.transform.localScale = Vector3.Lerp (box.transform.localScale, maxScale, (scaleTime*2) * Time.deltaTime);

		if (box.transform.localScale.x >= (maxScale.x - 0.001f)) {
			isScalingUp = false;
			return true;
		}
		return false;
	}

	public void EventStart()
	{
		isScalingDown = true;
		isScalingUp = false;
	}

	public void EventOver()
	{
		isScalingDown = false;
		isScalingUp = true;
	}

	void EventDestroy()
	{
		Debug.Log ("Wall Event Over... Destroy");
		box.transform.localScale = maxScale;
		Destroy (this.gameObject);
	}
}
