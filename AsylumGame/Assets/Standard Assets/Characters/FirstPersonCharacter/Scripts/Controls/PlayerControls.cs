using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour {

	public bool canSit;
	private List<GameObject> nearInteractables;

	void Start() {
		nearInteractables = new List<GameObject> ();
	}

	void Update () {
		if (canSit) {
			GameObject closestTerminal = getClosestTerminal ();
			if (Input.GetKeyDown (KeyCode.E)) {
				if(closestTerminal != null) closestTerminal.GetComponent<ScreenTextEditor>().setEditing();
				GetComponent<Sitting>().sit();
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				if(closestTerminal != null) closestTerminal.GetComponent<ScreenTextEditor>().setPending();
				GetComponent<Sitting>().getUp();
			}
		}
	}

	public bool canMove() {
		return !GetComponent<Sitting>().isSitting() && !GetComponent<Sitting>().isMoving();
	}

	public void addInteractable(GameObject interactableObject) {
		nearInteractables.Add (interactableObject);
	}

	public void removeInteractable(GameObject interactableObject) {
		nearInteractables.Add (interactableObject);
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
