using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    //initialisator
    public float maxHp;
    public bool progressBar;


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
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // Take dommage
    private void takeDommage() {
        hitpoint--;
    }

    // Heal dommage
    private void healDommage()
    {
        hitpoint++;
    }

    // verificator
    private void verificatorHealt() {
        if (progressBar) {
            if (maxHitpoint == hitpoint)
            {
                Debug.Log("FullHealt");
            }
        }
        else
        {
            if (hitpoint == 0)
            {
                Debug.Log("dead");
            }
        }
    }
    

    // Update le UI
    private void UpdateHealthBar() {
        float ratio = hitpoint / maxHitpoint;
        currentBar.rectTransform.localScale = new Vector3(ratio,1,1);
        currentText.text = (ratio * 100).ToString("0") + '%';

        verificatorHealt();
    }
}
