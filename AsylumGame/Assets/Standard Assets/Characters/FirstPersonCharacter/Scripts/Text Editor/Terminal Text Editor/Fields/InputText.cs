using UnityEngine;
using System.Collections;

public class InputText : MonoBehaviour {

	private string completed = "<File Complete>\n";
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
		
	public void showFileComplete() {
		mesh.text = mesh.text.Insert(0, completed);
	}
}
