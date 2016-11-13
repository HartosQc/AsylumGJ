using UnityEngine;
using System.Collections;

public class ScreenTextEditor : MonoBehaviour {

	public GameObject commandTextMeshObject;
	public GameObject storyTextMeshObject;
	public float crazyTextSpeed = 1.5f;
	private TextMesh commandTextMesh;
	private TextMesh storyTextMesh;
	private const string EDITABLE = "Press ";
	private const string ENTER = " to Enter";
	private const string EXIT = " to Exit";
	private const string END_TEXT = "GET OUT!";
	private int fileNumber;
	private bool ended;

	void Start () {
		commandTextMesh = commandTextMeshObject.GetComponent<TextMesh> ();
		storyTextMesh = storyTextMeshObject.GetComponent<TextMesh> ();
	}

	void Update() {
		if (storyTextMesh.GetComponent<InputText> ().isAllTextWritten ()) {
			if(!ended) StartCoroutine(crazyTextLoop());
			++fileNumber;
		}
	}

	IEnumerator crazyTextLoop() {
		ended = true;
		while (ended) {
			showEndText ();
			yield return new WaitForSeconds (crazyTextSpeed);
		}
	}

	public void setEditing() {
		commandTextMesh.text = EDITABLE + KeyCode.Q + EXIT;
		ended = false;
	}

	public void setPending() {
		commandTextMesh.text = EDITABLE + KeyCode.E + ENTER;
	}
		
	public void showEndText() {
		storyTextMeshObject.GetComponent<InputText>().addMessage(END_TEXT);
	}
}
