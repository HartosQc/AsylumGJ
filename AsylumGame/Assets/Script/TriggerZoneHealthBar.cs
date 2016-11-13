using UnityEngine;
using System.Collections;

public class TriggerZoneHealthBar : MonoBehaviour {

    //initialisator
    public float dommage;
    public bool isDoubleBarGestion;
    public bool isBalecheBar; // give one bar and heal an other
    
    public bool isIncreaceWithTime;
    public bool isDommaging;
    public GameObject affectedHPBar1;
    public GameObject affectedHpBar2;
    private bool isStop = false;

    private float timeCounter = 0;
    private float timeFix = 0;

    void Update()
    {
        
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
        if (isIncreaceWithTime)
        {
            if (timeCounter > timeFix + 1)
            {
                keypress();
                timeFix = timeCounter;
            }
            timeCounter = timeCounter + Time.deltaTime;
        }
        
    }

    private void dommageGestion(bool orrintation) {
        if (isBalecheBar)
        {
            if (isDoubleBarGestion && orrintation)
            {
                dmgAndHeal(affectedHPBar1, true);
                dmgAndHeal(affectedHpBar2, false);
            }
            else if (isDoubleBarGestion && !orrintation)
            {
                dmgAndHeal(affectedHPBar1, false);
                dmgAndHeal(affectedHpBar2, true);
            }    
        }
        else
        {
            keypress();
        }
        
    }

    private void dmgAndHeal(GameObject that, bool dif) {
        if (dif)
        {
            HealthBar other = (HealthBar)affectedHPBar1.GetComponent(typeof(HealthBar));
            other.healDommage(dommage);
        }
        else
        {
            HealthBar other = (HealthBar)affectedHPBar1.GetComponent(typeof(HealthBar));
            other.takeDommage(dommage);
        }
    }

    private void keypress() {
        if (!isStop)
        {
            HealthBar other = (HealthBar)affectedHPBar1.GetComponent(typeof(HealthBar));
            other.healDommage(dommage);
        }
       
    }

    private void OnTriggerStay(Collider col) {
        if (col.tag == "player") {
            dommageGestion(true);
        }
        else
        {
            dommageGestion(false);
        }
    }
}
