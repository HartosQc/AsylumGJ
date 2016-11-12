using UnityEngine;
using System.Collections;
using System.Threading;

public class FlickeringText : MonoBehaviour {

	public float timeOn = 0.8f;
	public float timeOff = 0.5f;
	public string character = "_";
	private Thread flickeringThread;
	private bool caracterDisplayed;

	void Start () {
		StartCoroutine(flickeringLoop());
	}

	IEnumerator flickeringLoop() {
		while (true) {
			flickerText (character);
			if (isCaracterDisplayed ())
				yield return new WaitForSeconds (timeOn);
			else {
				yield return new WaitForSeconds (timeOff);
			}
		}
	}

	private void flickerText(string character) {
		TextMesh mesh = GetComponent<TextMesh> ();
		if (isCaracterDisplayed()) {
			mesh.text = mesh.text.Substring (0, mesh.text.Length - 1);
		} else {
			mesh.text += character;
		}
	}

	private bool isCaracterDisplayed() {
		return GetComponent<TextMesh> ().text.EndsWith(character);
	}
}
