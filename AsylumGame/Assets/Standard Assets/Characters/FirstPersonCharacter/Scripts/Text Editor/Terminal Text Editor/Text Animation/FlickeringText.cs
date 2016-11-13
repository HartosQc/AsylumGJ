using UnityEngine;
using System.Collections;
using System.Threading;

public class FlickeringText : MonoBehaviour {

	public float timeOn = 0.8f;
	public float timeOff = 0.5f;
	public string character = "_";
	private Thread flickeringThread;
	private bool caracterDisplayed;
	private TextMesh mesh;

	void Start () {
		mesh = GetComponent<TextMesh> ();
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
		if (isCaracterDisplayed()) {
			mesh.text = mesh.text.Substring (0, mesh.text.Length - 1);
		} else {
			mesh.text += character;
		}
	}

	private bool isCaracterDisplayed() {
		return mesh.text.EndsWith(character);
	}
}
