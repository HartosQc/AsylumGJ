using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CreepyBadTrip : MonoBehaviour {

    private GameObject cam;
    private VignetteAndChromaticAberration vignette;
    private Vortex vortex;

    // Use this for initialization
    void Start () {
        GameObject[] reds;
        reds = GameObject.FindGameObjectsWithTag("MaineCamera");
        cam = reds[0];

        vignette = (VignetteAndChromaticAberration)cam.GetComponent(typeof(VignetteAndChromaticAberration));
        vortex = (Vortex)cam.GetComponent(typeof(Vortex));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // clignement d'yeux
    private void blink() {
        //vignette.v
    }




}
