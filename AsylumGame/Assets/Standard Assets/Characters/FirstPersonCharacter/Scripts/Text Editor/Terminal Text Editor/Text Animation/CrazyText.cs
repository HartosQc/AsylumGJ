using UnityEngine;
using System.Collections;

public class CrazyText : MonoBehaviour {

	public string crazyFile = "crazy.txt";
	public float crazyTextSpeed = 0.002f;
	private float oldSpeed;
	private bool started;

	public void start() {
		GetComponent<OutputText> ().auto = true;
		GetComponent<OutputText> ().setRepeat(true);
		oldSpeed = GetComponent<OutputText> ().timeByCharacter;
		GetComponent<OutputText> ().setTextFromFile (crazyFile);
		GetComponent<OutputText> ().timeByCharacter = crazyTextSpeed;
	}

	public void stop() {
		GetComponent<OutputText> ().setRepeat(false);
		GetComponent<OutputText> ().auto = false;
		GetComponent<OutputText> ().timeByCharacter = oldSpeed;
	}

	public bool isStarted() {
		return GetComponent<OutputText> ().auto;
	}
}
