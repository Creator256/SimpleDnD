using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommandLine : MonoBehaviour {

	public Text consoleOutput;

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
			PrintText(listCMD);
			break;
		case "add":
			Add(listCMD);
			break;
		case "help":
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

		}
		consoleOutput.text = tempText;
	}

	void Add(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a + b;
		consoleOutput.text = a.ToString() + " + " + b.ToString() + " = " + c.ToString();
	}

	void Help(){
		consoleOutput.text = "Commands Available: \n " +
		"Help - Prints help ~ help" +
		"Print - Prints out whatever ~ print text" +
		"Add - Adds numbers ~ add a b" +
		"Subract - Subtracts number ~ subtract a b" +
		"Roll - Random number between [a,b] ~ roll a b" +
		"TextColor - Changes text color ~ tColor R G B" +
		"Clear - clears console ~ clear" +
		"Name - changes your name ~ name text";
	
	}
}
