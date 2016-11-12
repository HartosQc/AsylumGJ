﻿using UnityEngine;
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
			ScreenTextEditor editor = closestTerminal.GetComponent<ScreenTextEditor> ();
			if (!controls.isSitting() && Input.GetKeyDown (KeyCode.E)) {
				editor.setEditing();
				controls.sit();
			} else if (controls.isSitting() && Input.GetKeyDown (KeyCode.Q)) {
				editor.setPending();
				controls.getUp();
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
