using UnityEngine;
using System.Collections;

abstract public class ScaryEvent : MonoBehaviour {

    public virtual void playEvent() {
        Debug.Log("boo");
    }

    public void destroyEvent() { }

    public void reactivePlate() {
        
        GameObject[] reds;
        reds = GameObject.FindGameObjectsWithTag("GameMasterHB");
        foreach (GameObject r in reds)
        {
            HealthBar healthBar = (HealthBar)r.GetComponent(typeof(HealthBar));
            healthBar.interactPlate(true);
        }
    }

}
