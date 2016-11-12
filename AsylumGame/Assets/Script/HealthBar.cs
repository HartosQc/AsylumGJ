﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    //initialisator
    public float maxHp;
    public bool progressBar;
    public bool isTrigger = false;
    public bool isLunch = false; 
    public bool isRollback; 
    public GameObject GameEventManager;

    //parameter of Helthbar
    private float hitpoint;
    private float maxHitpoint;

    //Element of UI
    public Image currentBar;
    public Text currentText;

    // Use this for initialization
    void Start () {
        if (maxHp > 0)
        {
            maxHitpoint = maxHp;
        }
        else {
            maxHitpoint = 100;
        }

        hitpoint = 0;
        UpdateHealthBar();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateHealthBar();

    }

    // Take dommage
    public void takeDommage(float damage) {
        if (!isTrigger && hitpoint != 0)
            hitpoint -= damage;
    }

    // Heal dommage
    public void healDommage(float damage)
    {
        if (!isTrigger && hitpoint != maxHitpoint)
            hitpoint += damage;
    }

    // verificator
    private bool verificatorHealt() {
        if (isTrigger)
        {
            return true;
        }
        else
        {
            if (progressBar) {
                if (maxHitpoint == hitpoint)
                {
                    isTrigger = true;
                    Debug.Log("FullHealt");
                    return false;
                }
            }
            else
            {
                if (hitpoint == 0)
                {
                    isTrigger = true;
                    Debug.Log("dead");
                    return false;
                }
            }
        }
        return false;
        
    }

    // rollback the value of the bar
    private void rollbackBar() {
        isTrigger = false;
        isLunch = false;
        if (progressBar)
        {
            hitpoint = 0;
        }
        else
        {
            hitpoint = maxHitpoint;
        }
    }

    private void lunchEvent() {
        isLunch = true;
        GameEventManager other = (GameEventManager)GameEventManager.GetComponent(typeof(GameEventManager));
        other.activeFirstEvent();
        Debug.Log("lol?");
    }
    

    // Update le UI
    private void UpdateHealthBar() {
        float ratio = hitpoint / maxHitpoint;
        currentBar.rectTransform.localScale = new Vector3(ratio,1,1);
        currentText.text = (ratio * 100).ToString("0") + '%';

        if (verificatorHealt())
        {
            
            if (isRollback) {
                rollbackBar();
            }

            if (!isLunch)
            {
                lunchEvent();
            }
            
        }
        
    }
}
