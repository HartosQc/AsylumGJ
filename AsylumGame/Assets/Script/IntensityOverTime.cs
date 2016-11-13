using UnityEngine;
using System.Collections;

public class IntensityOverTime : MonoBehaviour {

	public float intensity = 0;
	public float maxIntensity = 1;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (intensity < maxIntensity) {
		
			intensity += Time.deltaTime * 0.01f;
		}
	
	}
}
