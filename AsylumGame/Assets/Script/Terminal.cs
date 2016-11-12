using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {

	public void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == Tags.PLAYER){
			Debug.Log ("Terminal close");
			//other.gameObject.GetComponent<Movement> ().move();
			//other.GetComponent<UI> ().showInteraction ();
		}
	}
}
