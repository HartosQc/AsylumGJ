using UnityEngine;
using System.Collections;

public class TextWrapper : MonoBehaviour {

	public int maxChars = 30; 

	private TextMesh textObject;

	public void Start () {
		textObject = GetComponent<TextMesh> ();
		updateText();
	}

	private void updateText () {
		FormatString(textObject.text);
	}

	private void FormatString (string text) {
		int currentLine = 1;
		int charCount = 0;
		string[] words = text.Split(" "[0]); 
		string result = "";

		for (var index = 0; index < words.Length; index++) {

			var word = words[index].Trim();

			if (index == 0) {
				result = words[0];
				textObject.text = result;
			} else if (index > 0) {
				charCount += word.Length + 1;
				if (charCount <= maxChars) {
					result += " " + word;
				}
				else {
					charCount = 0;
					result += "\n" + word;
				}
					
				textObject.text = result;
			}
		}
	}
}
