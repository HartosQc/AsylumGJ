using UnityEngine;
using System.Collections;

public class EventRouge : ScaryEvent
{
    public override void playEvent()
    {
        Debug.Log("rouge");
    }

    public void destroyEvent() { }

}
