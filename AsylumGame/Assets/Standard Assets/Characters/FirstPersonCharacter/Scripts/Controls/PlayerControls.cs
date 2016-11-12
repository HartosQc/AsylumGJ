using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public bool canSit;

	void Update () {
		if (canSit) {
			if (Input.GetKeyDown(KeyCode.E))
				GetComponent<Sitting>().sit();

			if (Input.GetKeyDown(KeyCode.Q))
				GetComponent<Sitting>().getUp();
		}
	}

	public bool canMove() {
		return !GetComponent<Sitting>().isSitting() && !GetComponent<Sitting>().isMoving();
	}
}
