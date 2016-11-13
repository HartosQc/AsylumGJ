using UnityEngine;
using System.Collections;
using System.Threading;

public class OutputText : MonoBehaviour {

	public bool auto;
	public int charByKeypress = 1;
	public float timeByCharacter = 2.4f;

	private string text = "";
	private string word;
	private int currentCharIndex = 0;
	private int indexInWord;
	private bool autoStarted;
	private int lineNumber;
	private TextMesh mesh;
	private bool canInput;
	private bool repeat;

	public void Start() {
		mesh = GetComponent<TextMesh> ();
	}


	public void Update() {
		checkForInput ();
	}

	public void setRepeat(bool repeat) {
		this.repeat = repeat;
	}

	public void setCanInput(bool input) {
		canInput = input;
	}

	public void setAuto(bool auto) {
		this.auto = auto;
	}

	public void setTextFromFile(string filename) {
		resetText ();
		text = readFile (filename);
	}

	public void addTextFromFile(string filename) {
		text += readFile (filename);
	}

	public bool isAllTextWritten() {
		return currentCharIndex == text.Length;
	}

	IEnumerator autoWritingLoop() {
		while (auto && canInput) {
			if (isAllTextWritten ()) {
				if (repeat) {
					resetText ();
				}
			} else {
				writeAutoCharacter ();
			}
			yield return new WaitForSeconds (timeByCharacter);
		}
		autoStarted = false;
	}

	private string readFile(string filename) {
		FileReader reader = new FileReader();
		return reader.readFile(filename);
	}

	private void checkForInput() {
		if (canInput) {
			if (!auto) {
				if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Q) && !isAllTextWritten())
					writeInputCharacter ();
			} else {
				if (!autoStarted) {
					autoStarted = true;
					StartCoroutine(autoWritingLoop());
				}
			}
		}
	}

	private void writeInputCharacter() {
		for(int i = 0; i < charByKeypress && currentCharIndex <= text.Length; ++i) {
			writeCharacter ();
		}
	}

	private void writeAutoCharacter() {
		if (indexInWord == word.Length || currentCharIndex == 0) {
			word = getCurrentWord ();
			mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, word, getCurrentChar ());
		} else {
			++indexInWord;
			mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, getCurrentChar ());
		}
		++currentCharIndex;
	}

	private void writeCharacter() {
		if (indexInWord == word.Length || currentCharIndex == 0) {
			word = getCurrentWord ();
			mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, word, getCurrentChar ());
		} else {
			++indexInWord;
			mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, getCurrentChar ());
		}
		++currentCharIndex;
	}

	private string getCurrentChar() {
		return text.Substring(currentCharIndex, 1);
	}

	private string getCurrentWord() {
		string currentWord = "";
		if (getCurrentChar() != " ") {
			currentWord = text.Substring(currentCharIndex, text.IndexOf(" ",currentCharIndex) - currentCharIndex);
		}
		indexInWord = 0;
		return currentWord;
	}

	private void resetText() {
		mesh.text = "";
		word = "";
		currentCharIndex = 0;
	}
}
