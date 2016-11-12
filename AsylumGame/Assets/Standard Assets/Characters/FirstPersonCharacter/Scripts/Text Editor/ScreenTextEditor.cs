using UnityEngine;
using System.Collections;

public class ScreenTextEditor : MonoBehaviour {

	public GameObject textMeshObject;
	private TextMesh textMesh;
	private const string EDITABLE = "Press ";
	private const string ENTER = " to Enter";
	private const string EXIT = " to Exit";

	void Start () {
		textMesh = textMeshObject.GetComponent<TextMesh> ();
	}

	public void setEditing() {
		textMesh.text = EDITABLE + KeyCode.Q + EXIT;
	}

	public void setPending() {
		textMesh.text = EDITABLE + KeyCode.E + ENTER;
	}
}
