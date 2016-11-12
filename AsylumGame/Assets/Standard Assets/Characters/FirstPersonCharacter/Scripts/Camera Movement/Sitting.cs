using UnityEngine;
using System.Collections;

public class Sitting : Movement {

	private bool sitting;

	public void sit() {
		if (!sitting) {
			sitting = true; 
			move (new Vector3(0, transform.localScale.y/2 * -1, 0)); 
		}
	}

	public void getUp() {
		if (sitting) {
			sitting = false;
			move (new Vector3(0, transform.localScale.y/2, 0)); 
		}
	}

	public bool isSitting() {
		return sitting;
	}
}
