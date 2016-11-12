using UnityEngine;
using System.Collections;

abstract public class ScaryEvent : MonoBehaviour {

    public virtual void playEvent() {
        Debug.Log("boo");
    }

    public void destroyEvent() { }

}
