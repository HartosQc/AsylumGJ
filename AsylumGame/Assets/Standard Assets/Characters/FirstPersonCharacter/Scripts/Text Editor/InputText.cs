using UnityEngine;
using System.Collections;
using System.Threading;

public class InputText : MonoBehaviour {

	public bool auto;
	public string fileName;
	public float timeByCharacter = 2.4f;
	public int lineLenght = 14;
	public int maxLine = 4;
	public bool isCompact = false;
	private string text = "";
	private Thread flickeringThread;
	private int lastCharIndex;
	private bool autoStarted;
	private int lineNumber;
	private int charSkip;

	public void Start() {
		FileReader reader = new FileReader();
		text = reader.readFile(fileName);
		resetText ();
	}

	void Update() {
		if (!auto) {
			if (Input.anyKeyDown && !isAllTextWritten())
				writeCharacter ();
		} else {
			if (!autoStarted) {
				StartCoroutine(autoWritingLoop());
				autoStarted = true;
			}
		}
	}

	public void addMessage(string text) {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text += text;
		addLine ();
		if(isScreenFull()) {
			removeFirstLine ();
		}
	}

	public bool isAllTextWritten() {
		return lastCharIndex == text.Length;
	}

	IEnumerator autoWritingLoop() {
		while (auto) {
			if (isAllTextWritten ()) {
				resetText ();
			} else {
				writeCharacter ();
			}
			yield return new WaitForSeconds (timeByCharacter);
		}
	}

	private void writeCharacter() {
		checkForNewLines ();
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text += getNextChar ();
		++lastCharIndex;
		--charSkip;
	}

	private void checkForNewLines() {
		TextMesh mesh = GetComponent<TextMesh> ();
		if (mesh.text.Length != text.Length) {
			if (charSkip == 0 && isWordToLarge () && !isCompact) {
				Debug.Log ("word new line");
				addLine();
			}
			if(isEndLine () && isCompact) {
				Debug.Log ("end line newLine");
				addLine ();
			}
			if(isScreenFull()) {
				removeFirstLine ();
			}
		}
	}

	private string getNextChar() {
		return text.Substring(lastCharIndex, 1);
	}

	private bool isEndLine() {
		TextMesh mesh = GetComponent<TextMesh> ();
		return mesh.text.Length % lineLenght == 0 && mesh.text.Length != 0;
	}

	private bool isScreenFull() {
		TextMesh mesh = GetComponent<TextMesh> ();
		return mesh.text.Length/lineLenght == maxLine + 1;
	}

	private void resetText() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text = "";
		lastCharIndex = 0;
	}

	private void addLine() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text += "\n";
		++lineNumber;
	}

	private void removeFirstLine() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text = mesh.text.Substring(lineLenght + 1);
		--lineNumber;
	}

	private bool isWordToLarge() {
		TextMesh mesh = GetComponent<TextMesh> ();
		int charLeft = lineLenght - (mesh.text.Length % lineLenght);
		string word = text.Substring(lastCharIndex, text.IndexOf(" ",lastCharIndex) - lastCharIndex);
		charSkip = word.Length + 1;
		return word.Length >= charLeft - 1;
	}
}
