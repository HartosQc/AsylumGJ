using UnityEngine;
using System.Collections;

public class AudioOscilator : MonoBehaviour {

    public float oscilWidth;
    public float oscilStrength;
    public float INTENSITY_TO_REPLACE;
    private float oscilPos;
    private bool goingUp;
    private float currentIntensity;
    private AudioSource currentAudioSource;
	// Use this for initialization
	void Start () {
        goingUp = true;
        oscilPos = 0;

        
    }
	
	// Update is called once per frame
	void Update () {
        currentIntensity = INTENSITY_TO_REPLACE / 4f;
        currentAudioSource = gameObject.GetComponent<AudioSource>();
   
        if (currentAudioSource.pitch < 1f + 1f * currentIntensity * oscilWidth && goingUp) {
 
            currentAudioSource.pitch += oscilStrength * 0.1f * currentIntensity;
        }
        else
        {
            goingUp = false;
        }

        if (currentAudioSource.pitch > 1f - 1f * currentIntensity * oscilWidth && !goingUp)
        {
            currentAudioSource.pitch -= oscilStrength * 0.1f * currentIntensity;
        }
        else
        {
            goingUp = true;
        }
        currentAudioSource.volume = 1f * INTENSITY_TO_REPLACE * 0.0002f;
       
    }
}
