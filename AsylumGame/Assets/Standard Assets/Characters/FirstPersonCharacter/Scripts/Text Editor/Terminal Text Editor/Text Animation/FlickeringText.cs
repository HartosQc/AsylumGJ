using UnityEngine;
using System.Collections;
using System.Threading;

[RequireComponent (typeof (TextMesh))]
public class FlickeringText : MonoBehaviour {

	public float timeOn = 0.8f;
	public float timeOff = 0.5f;
	public string character = "_";
	private Thread flickeringThread;
	private bool characterDisplayed;
	private TextMesh mesh;

	void Start () {
		mesh = GetComponent<TextMesh> ();
		StartCoroutine(flickeringLoop());
	}

	IEnumerator flickeringLoop() {
		while (true) {
			updateFlicker ();
			if (!characterDisplayed) {
				yield return new WaitForSeconds (timeOn);
			} else {
				yield return new WaitForSeconds (timeOff);
			}
		}
	}

	private void updateFlicker () {
		if (characterDisplayed) {
			showChar ();
		} else {
			hideChar ();
		}
	}

	private void showChar() {
		characterDisplayed = true;
		mesh.text += character;
	}

	private void hideChar() {
		characterDisplayed = false;
		mesh.text = mesh.text.Substring (0, mesh.text.LastIndexOf (character));
	}
}
