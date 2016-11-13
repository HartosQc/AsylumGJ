using UnityEngine;
using System.Collections;

public class InputText : MonoBehaviour {

	private TextMesh mesh;
	private bool ended;

	void Start () {
		mesh = GetComponent<TextMesh> ();
	}

	public void setEditing() {
		mesh.text = Words.EDITABLE + KeyCode.Q + Words.EXIT;
	}

	public void setPending() {
		mesh.text = Words.EDITABLE + KeyCode.E + Words.ENTER;
	}
}
