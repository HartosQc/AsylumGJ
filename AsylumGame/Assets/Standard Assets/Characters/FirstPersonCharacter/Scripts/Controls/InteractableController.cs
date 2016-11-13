using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableController {

	private List<GameObject> nearInteractables;

	public InteractableController() {
		nearInteractables = new List<GameObject> ();
	}

	public void addInteractable(GameObject interactableObject) {
		nearInteractables.Add (interactableObject);
	}

	public void removeInteractable(GameObject interactableObject) {
		nearInteractables.Add (interactableObject);
	}

	public void interactWithTerminal(PlayerControls controls) {
		GameObject closestTerminal = getClosestTerminal ();
		if (controls.canMove() && closestTerminal != null) {
			EmancipationEditor editor = closestTerminal.GetComponent<EmancipationEditor> ();
			if (!controls.isSitting() && Input.GetKeyDown (KeyCode.E)) {
				editor.loadNewPage ();
				editor.getInputText().setEditing();
				controls.sit();
				editor.getOutputText().setCanInput(true);
			} else if (controls.isSitting() && Input.GetKeyDown (KeyCode.Q)) {
				editor.getInputText().setPending();
				controls.getUp();
				editor.getOutputText().setCanInput(false);
			}
		}
	}

	private GameObject getClosestTerminal() {
		foreach(GameObject interactable in nearInteractables){
			if(interactable.tag == Tags.TERMINAL){
				return interactable;
			}
		}
		return null;
	}
}
