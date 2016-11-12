using UnityEngine;
using System.Collections;

public class StringCommands : MonoBehaviour {

	private const string commandStart = "</";
	private const string commandEnd = ">";
	private const string newLine = "newLine";
	private const string tab = "tab";
	private const string clearScreen = "clear";

	public bool isCommand(string text) {
		return text.Substring (0, commandStart.Length) == commandStart && text.Substring (text.Length - commandEnd.Length, commandEnd.Length) == commandEnd;
	}

	public string getCommandStart() {
		return commandStart;
	}

	public string getCommandEnd() {
		return commandEnd;
	}

	public bool isClearScreen(string text) {
		return text == clearScreen;
	}

	public string decodeString(string text) {
		switch (parseCommand(text)) {
		case newLine: return "\n";
		case tab: return "\t";
		case clearScreen: return clearScreen;
		default: return "";
		}
	}

	private string parseCommand(string text) {
		string parsedCommand = text;
		parsedCommand.Remove (commandStart.Length);
		parsedCommand.Remove (text.Length - commandEnd.Length);
		return parsedCommand;
	}
}
