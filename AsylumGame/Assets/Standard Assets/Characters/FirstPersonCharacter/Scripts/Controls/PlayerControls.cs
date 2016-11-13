using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour {

	private InteractableController interactableControl;
	private bool canSit = true;

	void Start() {
		interactableControl = new InteractableController ();
	}

	void Update () {
		interactableControl.interactWithTerminal (GetComponent<PlayerControls>());
	}

	public void setCanSit(bool canSit) {
		this.canSit = canSit;
	}

	public bool isCanSit() {
		return canSit;
	}

	public void sit() {
		GetComponent<Sitting> ().sit ();
	}

	public void getUp() {
		GetComponent<Sitting> ().getUp ();
	}

	public bool canMove() {
		return !GetComponent<Sitting>().isMoving();
	}

	public bool isSitting() {
		return GetComponent<Sitting> ().isSitting ();
	}

	public void addInteractable(GameObject interactableObject) {
		interactableControl.addInteractable (interactableObject);
	}

	public void removeInteractable(GameObject interactableObject) {
		interactableControl.removeInteractable (interactableObject);
	}
}