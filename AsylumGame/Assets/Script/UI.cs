using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GUIText actionText;

	public void showInteraction() {
		actionText.text = "Press E";
	}
}
