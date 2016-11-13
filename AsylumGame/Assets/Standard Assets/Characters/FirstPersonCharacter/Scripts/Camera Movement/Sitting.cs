using UnityEngine;
using System.Collections;

public class Sitting : Movement {

	private bool sitting;
	private float movement;

	public void sit() {
		if (!sitting) {
			movement = transform.localScale.y / 4;
			sitting = true; 
			move (new Vector3(0, movement * -1, 0)); 
		}
	}

	public void getUp() {
		if (sitting) {
			sitting = false;
			move (new Vector3(0, movement, 0)); 
		}
	}

	public bool isSitting() {
		return sitting;
	}
}
