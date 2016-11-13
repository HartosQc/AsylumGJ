﻿using UnityEngine;
using System.Collections;

public class TriggerZoneHealthBar : MonoBehaviour {

    //initialisator
    public float dommage;
    public bool isDommaging;
    public GameObject affectedHealtBar;
    private bool isStop = false;

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

    // activer le take / heal Dommage 
    public void activeProgress()
    {
        isStop = false;
    }

    // desactive le take / heal Dommage 
    public void desactiveProgress()
    {
        isStop = true;
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
        if (!isStop)
        {
            HealthBar other = (HealthBar)affectedHealtBar.GetComponent(typeof(HealthBar));
            other.healDommage(dommage);
        }
       
    }

    private void OnTriggerStay(Collider col) {
        if (col.tag == "player") {
            HealthBar other = (HealthBar)affectedHealtBar.GetComponent(typeof(HealthBar));
            other.healDommage(dommage);
        }     
    }
}
