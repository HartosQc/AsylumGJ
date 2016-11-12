using UnityEngine;
using System.Collections;

public class TriggerZoneHealthBar : MonoBehaviour {

    //initialisator
    public float dommage;
    public bool isDommaging;
    public GameObject go;

    private float timeCounter = 0;
    private float timeFix = 0;

    void Update()
    {
        //if (timeCounter > timeFix + 1)
        //{
        //    keypress();
        //    timeFix = timeCounter;
        //}
        //timeCounter = timeCounter + Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeCounter > timeFix + 1)
        {
            keypress();
            timeFix = timeCounter;
        }
        timeCounter = timeCounter + Time.deltaTime;
    }

    private void keypress() {
        HealthBar other = (HealthBar)go.GetComponent(typeof(HealthBar));
        other.healDommage(dommage);
    }

    private void OnTriggerStay(Collider col) {
        if (col.tag == "player") {
            HealthBar other = (HealthBar)go.GetComponent(typeof(HealthBar));
            other.healDommage(dommage);
        }     
    }
}
