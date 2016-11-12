using UnityEngine;
using System.Collections;

public class Sitting : Movement {

	private bool sitting;

	public void sit() {
		if (!sitting) {
			sitting = true; 
			move (Vector3.down); 
		}
	}

	public void getUp() {
		if (sitting) {
			sitting = false;
			move (Vector3.up); 
		}
	}

	public bool isSitting() {
		return sitting;
	}
}
