using UnityEngine;
using System.Collections;

public abstract class EventTrigger : MonoBehaviour {

	public abstract void enterAction (GameObject player);
	public abstract void exitAction (GameObject player);

	public void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == Tags.PLAYER){
			enterAction(other.gameObject);
		}
	}

	public void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == Tags.PLAYER){
			exitAction(other.gameObject);
		}	
	}
}
