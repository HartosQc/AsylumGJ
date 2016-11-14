using UnityEngine;
using System.Collections;

public class fadeScript : MonoBehaviour {
    public float fadeTime;
    private float timePassed;
    public float timeStartFade;
    public float fadeSpeed;

    private float alphaMat; 
    void Start()
    {
        fadeSpeed /= 100; 
    }
    void FixedUpdate () {
        timePassed += Time.deltaTime;
        print(timePassed);
        if(timePassed > timeStartFade && timePassed < timeStartFade + fadeTime)
        {
            alphaMat = GetComponent<Renderer>().material.color.a;
            print(alphaMat);
            if(alphaMat - fadeSpeed < 0)
            {
                alphaMat = 0;
            }
            else
            {
                alphaMat = alphaMat - fadeSpeed;
            }
            GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, 
                                                                GetComponent<Renderer>().material.color.g,
                                                                GetComponent<Renderer>().material.color.b, alphaMat);
        }
    }
}
