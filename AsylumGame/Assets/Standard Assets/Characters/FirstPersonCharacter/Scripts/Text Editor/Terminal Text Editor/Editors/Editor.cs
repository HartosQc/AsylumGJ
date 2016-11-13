using UnityEngine;
using System.Collections;

public abstract class Editor : MonoBehaviour {

	public GameObject inputGameObject;
	public GameObject outputGameObject;

	public InputText getInputText() {
		return inputGameObject.GetComponent<InputText> ();
	}

	public OutputText getOutputText() {
		return outputGameObject.GetComponent<OutputText> ();
	}
}
