using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommandLine : MonoBehaviour {

	public Text consoleOutput;
	string name;

	// Use this for initialization
	void Start () {
		InputField input = GetComponent<InputField> ();
		input.onEndEdit.AddListener (ParseCommand);
	}
	
	// Update is called once per frame
	void ParseCommand (string pCMD) {
		string[] splitCMD = pCMD.Split (' ');
		List<string> listCMD = new List<string>();
		for (int i = 0; i < splitCMD.Length; i++) {
			listCMD.Add(splitCMD[i]);
		}
		string cmdVal = listCMD[0];
		listCMD.RemoveAt(0);

		switch (cmdVal) {
			case "print":
				consoleOutput.text += "\n";
				PrintText(listCMD);
				break;
			case "add":
				consoleOutput.text += "\n";
				Add(listCMD);
				break;
			case "subtract":
				consoleOutput.text += "\n";
				Subtract(listCMD);
				break;
			case "roll":
				consoleOutput.text += "\n";
				Roll(listCMD);
				break;
			case "tColor":
				//Doesnt need a new line because it doesnt print anything
				TextColor (listCMD);
				break;
			case "clear":
				consoleOutput.text = " ";
				break;
			case "name":
				consoleOutput.text += "\n";
				Name ();
				break;
			case "cName":
				consoleOutput.text += "\n";
				ChangeName (listCMD);
				break;
			case "help":
				consoleOutput.text += "\n";
				Help ();
				break;
			default:
				consoleOutput.text = "Invalid Command!";
				break;

		}
	}

	void PrintText(List<string> cmdParams){
		string tempText = "";
		for (int i = 0; i < cmdParams.Count; i++) {
			tempText += cmdParams[i];
			tempText += " ";
		}
		consoleOutput.text += tempText;
	}

	void Add(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a + b;
		consoleOutput.text += a.ToString() + " + " + b.ToString() + " = " + c.ToString();
	}

	void Subtract(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a - b;
		consoleOutput.text += a.ToString() + " - " + b.ToString() + " = " + c.ToString();
	}

	void Roll(List<string> cmdParams){
		int lower = 1;
		int upper = 6;
		if(cmdParams.Count != 0){
			lower = Convert.ToInt32(cmdParams[0]);
			upper = Convert.ToInt32(cmdParams[1]);
		}
		int roll = (int)(UnityEngine.Random.Range(lower, upper));

		consoleOutput.text += "A " + upper.ToString() + " dice rolled a " + roll.ToString() + "!";
	}

	void TextColor (List<string> cmdParams){
		int red = Convert.ToInt32(cmdParams [0]);
		int green = Convert.ToInt32(cmdParams [1]);
		int blue = Convert.ToInt32(cmdParams [2]);
		consoleOutput.color = new Color (red, green, blue, 1);
	}

	void Name(){
		consoleOutput.text += "Your name is " + name;
	}

	void ChangeName(List<string> cmdParams){
		name = cmdParams [0];
		consoleOutput.text += "You have changed your name to " + name;
	}

	void Help(){
		consoleOutput.text += "Commands Available:\n" +
		"Help - Prints help = help\n" +
		"Print - Prints out whatever = print text\n" +
		"Add - Adds numbers = add a b\n" +
		"Subract - Subtracts number = subtract a b\n" +
		"Roll - Random number between [a,b] = roll a b\n" +
		"TextColor - Changes text color = tColor dR G B\n" +
		"Clear - clears console = clear\n" +
		"ChangeName - changes your name = cName name\n" +
		"Name - prints your name = name\n";
		
	}
}
