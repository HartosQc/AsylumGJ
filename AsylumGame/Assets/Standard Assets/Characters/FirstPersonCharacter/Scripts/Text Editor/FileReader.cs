using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class FileReader {

	private string path = "Assets/Text/";

	public string readFile(string fileName) {
		try {
			string lines = "";
			string line;
			StreamReader theReader = new StreamReader(path + fileName, System.Text.Encoding.Default);
			using (theReader) {
				do {
					line = theReader.ReadLine();

					if (line != null) {
						lines += line;
					}
				}
				while (line != null);
				theReader.Close();
				return lines;
			}
		} catch (Exception e) {
			Debug.Log(e);
			return "";
		}
	}
}