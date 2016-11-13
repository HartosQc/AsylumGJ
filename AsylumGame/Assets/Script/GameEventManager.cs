using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEventManager : MonoBehaviour {

    public List<GameObject> eventList = new List<GameObject>();

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activeFirstEvent() {
        GameObject someEvent = eventList[0];
        ScaryEvent thisEvent = (ScaryEvent)someEvent.GetComponent(typeof(ScaryEvent));

        Debug.Log(thisEvent);
        thisEvent.playEvent();

        eventList.Remove(someEvent);
    }

  


}
