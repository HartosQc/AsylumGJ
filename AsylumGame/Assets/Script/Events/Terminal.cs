using UnityEngine;
using System.Collections;

public class Terminal : EventTrigger {


	public override void enterAction(GameObject player) {
		PlayerControls playerControls = player.GetComponent<PlayerControls> ();
		playerControls.addInteractable (this.gameObject);
	}

	public override void exitAction(GameObject player) {
		PlayerControls playerControls = player.GetComponent<PlayerControls> ();
		playerControls.removeInteractable (this.gameObject);
	}
}
