using UnityEngine;
using System.Collections;

public class OutputFormater : MonoBehaviour {

	public int lineLenght = 14;
	public int maxLine = 4;
	public bool isCompact = false;

	public string addCharacter(string text, string word, string character) {
		string newText = formatText (text, word) + character;
		return newText;
	}

	public string addCharacter(string text, string character) {
		string newText = text;
		newText += character;
		return newText;
	}

	public string addWord(string text, string word) {
		string newText = formatText (text, word) + word;
		return newText;
		
	}

	public string addLine(string text) {
		return text + "\n";
	}

	public string removeFirstLine(string text) {
		int indexOfNewLine = text.IndexOf ("\n");
		return text.Substring(indexOfNewLine + 2, text.Length - indexOfNewLine - 2);
	}

	public bool isWordToLarge(string text, string word) {
		int charLeft = lineLenght - (text.Length % lineLenght);
		return word.Length >= charLeft;
	}

	private bool isEndLine(string text) {
		int charLeft = lineLenght - (text.Length % lineLenght);
		return charLeft == 0 && text.Length > 0;
	}

	private bool isScreenFull(string text) {
		int lineCount = text.Length / lineLenght;
		return lineCount >= maxLine;
	}

	private string formatText(string text, string word) {
		string newText = text;
		Debug.Log (word.Length);
		if (isWordToLarge (text, word) && !isCompact) {
			newText = addLine (text);
		} else if (isEndLine (text) && isCompact) {
			newText = addLine (text);
		}
		if(isScreenFull(text)) {
			newText = removeFirstLine (text);
		}
		return newText;
	}
}
