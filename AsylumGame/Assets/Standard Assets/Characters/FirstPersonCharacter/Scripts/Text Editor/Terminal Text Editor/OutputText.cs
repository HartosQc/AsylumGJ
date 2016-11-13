using UnityEngine;
using System.Collections;
using System.Threading;

public class OutputText : MonoBehaviour {

	public bool auto;
	public int charByKeypress = 1;
	public float timeByCharacter = 2.4f;
	public string fileName;

	private string text = "";
	private string word;
	private int currentCharIndex = 0;
	private int indexInWord;
	private bool autoStarted;
	private int lineNumber;
	private TextMesh mesh;
	private bool canInput;

	public void Start() {
		mesh = GetComponent<TextMesh> ();
		setTextFromFile (fileName);
	}

	public void Update() {
		checkForInput ();
	}

	public void setCanInput(bool input) {
		canInput = input;
	}

	public void setTextFromFile(string filename) {
		readFile (filename);
		resetText ();
	}

	public void addTextFromFile(string filename) {
		readFile (filename);
	}

	public bool isAllTextWritten() {
		return currentCharIndex == text.Length;
	}

	IEnumerator autoWritingLoop() {
		while (auto && canInput) {
			if (isAllTextWritten ()) {
				resetText ();
			} else {
				writeAutoCharacter ();
			}
			yield return new WaitForSeconds (timeByCharacter);
		}
		autoStarted = false;
	}

	private void readFile(string filename) {
		FileReader reader = new FileReader();
		text = reader.readFile(fileName);
	}

	private void checkForInput() {
		if (canInput) {
			if (!auto) {
				if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Q) && !isAllTextWritten())
					writeCharacter ();
			} else {
				if (!autoStarted) {
					autoStarted = true;
					StartCoroutine(autoWritingLoop());
				}
			}
		}
	}

	private void writeCharacter() {
		for(int i = 0; i < charByKeypress && currentCharIndex <= text.Length; ++i) {
			if (indexInWord == word.Length || currentCharIndex == 0) {
				word = getCurrentWord ();
				mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, word, getCurrentChar ());
			} else {
				++indexInWord;
				mesh.text = GetComponent<OutputFormater> ().addCharacter (mesh.text, getCurrentChar ());
			}
			++currentCharIndex;
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
