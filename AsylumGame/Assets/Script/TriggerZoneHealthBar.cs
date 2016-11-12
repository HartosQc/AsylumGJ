using UnityEngine;
using System.Collections;

public class TriggerZoneHealthBar : MonoBehaviour {

    //initialisator
    public float dommage;
    public bool isDommaging;
    public GameObject go;

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            keypress();
        }

    }

    private void keypress() {

        HealthBar other = (HealthBar)go.GetComponent(typeof(HealthBar));
        other.healDommage(dommage);
    }

    private void OnTriggerStay(Collider col) {
        if (col.tag == "player") { }
        
    }
}
