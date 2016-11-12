using UnityEngine;
using System.Collections;

public class Terminal : EventTrigger {


	public override void enterAction(GameObject player) {
		PlayerControls playerControls = player.GetComponent<PlayerControls> ();
		playerControls.canSit = true;
		playerControls.addInteractable (this.gameObject);
	}

	public override void exitAction(GameObject player) {
		PlayerControls playerControls = player.GetComponent<PlayerControls> ();
		playerControls.canSit = false;
		playerControls.removeInteractable (this.gameObject);
	}
}
