using UnityEngine;
using System.Collections;

public class Terminal : EventTrigger {

	public override void enterAction(GameObject player) {
		player.GetComponent<PlayerControls> ().canSit = true;
	}

	public override void exitAction(GameObject player) {
		player.GetComponent<PlayerControls> ().canSit = false;
	}
}
