using UnityEngine;
using System.Collections;

public class EventBleu : ScaryEvent
{
    private float timeCounter = 0;
    private float timeFix = 0;

    public override void playEvent()
    {
        Debug.Log("Bleu");
    }

    public void destroyEvent() { }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            reactivePlate();
        }
    }
}
