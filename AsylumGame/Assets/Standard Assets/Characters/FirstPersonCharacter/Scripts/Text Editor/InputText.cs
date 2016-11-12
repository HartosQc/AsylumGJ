﻿using UnityEngine;
using System.Collections;
using System.Threading;

public class InputText : MonoBehaviour {

	public bool auto;
	public string fileName;
	public float timeByCharacter = 2.4f;
	public int lineLenght = 14;
	public int maxLine = 4;
	private string text = "";
	private Thread flickeringThread;
	private int lastCharIndex;
	private bool autoStarted;

	void Start() {
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
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text += text.Substring(lastCharIndex, 1);
		++lastCharIndex;
		if (isEndLine ()) {
			addLine ();
		}
		if(isScreenFull()) {
			removeFirstLine ();
		}
	}
		
	private bool isAllTextWritten() {
		return lastCharIndex == text.Length;
	}

	private bool isEndLine() {
		return lastCharIndex % lineLenght == 0;
	}

	private bool isScreenFull() {
		TextMesh mesh = GetComponent<TextMesh> ();
		return mesh.text.Length / lineLenght == maxLine;
	}

	private void resetText() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text = "";
		lastCharIndex = 0;
	}

	private void addLine() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text += "\n";
	}

	private void removeFirstLine() {
		TextMesh mesh = GetComponent<TextMesh> ();
		mesh.text = mesh.text.Substring(lineLenght + 1);
	}
}
