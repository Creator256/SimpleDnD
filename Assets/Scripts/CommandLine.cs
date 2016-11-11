using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommandLine : MonoBehaviour {

	public RectTransform console;
	Text consoleOutput;
	string name;
	public InputField input;
	public Text inputText;
	public Text beforeCMDText;
	public Color textColor;

	public List<ScriptablePlayer> players;

	void OnStart(){
	}

	void OnEnable () {
		consoleOutput = console.GetComponent<Text>();

		input.onEndEdit.AddListener(ParseCommand);
		consoleOutput.color = textColor;
		inputText.color = textColor;
		beforeCMDText.color = textColor;
	}


	//All command parsing
	//and commands are found below
	void ParseCommand (string pCMD) {
		input.text = ""; 
		input.ActivateInputField(); 
		input.Select();

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
				if(listCMD.Count > 0)
					PrintText(listCMD);
				break;
			case "add":
				consoleOutput.text += "\n";
				if(listCMD.Count > 0)
					Add(listCMD);
				break;
			case "subtract":
				consoleOutput.text += "\n";
				if(listCMD.Count > 0)
					Subtract(listCMD);
				break;
			case "roll":
				consoleOutput.text += "\n";
				if(listCMD.Count > 0)
					Roll(listCMD);
				break;
			case "tColor":
				//Doesnt need a new line because it doesnt print anything
				if(listCMD.Count > 0)
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
				if(listCMD.Count > 0)
					ChangeName (listCMD);
				break;
			case "getStats":
				consoleOutput.text += "\n";
				ScriptablePlayer tempGSplayer = new ScriptablePlayer();
				if (listCMD.Count > 0) {
					for (int i = 0; i < players.Count; i++) {
						if (players [i].playerName == listCMD [0]) {
							tempGSplayer = players [i];
							break;
						}
					}
				}
				PrintStats (tempGSplayer);
				break;
			case "changeStat":
				consoleOutput.text += "\n";
				ScriptablePlayer tempCSPlayer = new ScriptablePlayer ();
				if (listCMD.Count > 0) {
					for (int i = 0; i < players.Count; i++) {
						if (players [i].playerName == listCMD [0]) {
							tempCSPlayer = players [i];
							break;
						}
					}
				}
				listCMD.RemoveAt (0);
				ChangeStats(tempCSPlayer,listCMD);
				break;
			case "help":
				consoleOutput.text += "\n";
				Help ();
				break;
			default:
				consoleOutput.text += "\n";
				consoleOutput.text += "Invalid Command!";
				break;
		}
		//Check to see if console is now too long
//		if(console.rect.height >= 3900){
//			string conOut = consoleOutput.text;
//			string tempString = "";
//			string[] splitText = conOut.Split('\n');
//			List<string> stringList = new List<string>();
//			for(int x = 0; x < splitText.Length; x++){
//				stringList.Add(splitText[x]);
//			}
//			while(console.rect.height >= 3900){
//				stringList.RemoveAt(0);
//				for(int i = 0; i < stringList.Count; i++){
//					tempString += stringList[i];
//				}
//				consoleOutput.text = tempString;
//			}
//
//		}
	

	}

	void PrintText(List<string> cmdParams){
		string tempText = "Console: ";
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
		consoleOutput.text += "Console: " + a.ToString() + " + " + b.ToString() + " = " + c.ToString();
	}

	void Subtract(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a - b;
		consoleOutput.text += "Console: " + a.ToString() + " - " + b.ToString() + " = " + c.ToString();
	}

	void Roll(List<string> cmdParams){
		int lower = 1;
		int upper = 6;
		if(cmdParams.Count != 0){
			lower = Convert.ToInt32(cmdParams[0]);
			upper = Convert.ToInt32(cmdParams[1]);
		}
		int roll = (int)(UnityEngine.Random.Range(lower, upper));

		consoleOutput.text += "Console: " + "A " + upper.ToString() + " dice rolled a " + roll.ToString() + "!";
	}

	void TextColor (List<string> cmdParams){
		int red = Convert.ToInt32(cmdParams [0]);
		int green = Convert.ToInt32(cmdParams [1]);
		int blue = Convert.ToInt32(cmdParams [2]);
		Color newTextColor = new Color (red, green, blue, 1);
		consoleOutput.color = newTextColor;
		inputText.color = newTextColor;
		beforeCMDText.color = newTextColor;
	}

	void Name(){
		consoleOutput.text += "Console: " + "Your name is " + name;
	}

	void ChangeName(List<string> cmdParams){
		name = cmdParams [0];
		consoleOutput.text += "Console: " + "You have changed your name to " + name;
	}

	void PrintStats(ScriptablePlayer player){
		consoleOutput.text += "Name: " + player.playerName + "\n" +
		"Level: " + player.playerLevel + "\n" +
		"EXP: " + player.exp + "\n" +
		"Strength: " + player.strength + "\n" +
		"Agility: " + player.agility + "\n" +
		"Intelligence: " + player.intelligence + "\n" +
		"Vitality: " + player.vitality + "\n" +
		"Luck: " + player.luck + "\n";

	}
	void ChangeStats(ScriptablePlayer player, List<string> cmdParams){
		player.UpdateStat (cmdParams);
		consoleOutput.text += cmdParams [0] + " changed to " + cmdParams [1] + "\n";
	}

	void Help(){
		consoleOutput.text += "Commands Available:\n" +
		"Help - Prints help = help\n" +
		"Print - Prints out whatever = print text\n" +
		"Add - Adds numbers = add a b\n" +
		"Subract - Subtracts number = subtract a b\n" +
		"Roll - Random number between [a,b] = roll a b\n" +
		"TextColor - Changes text color = tColor R G B\n" +
		"Clear - clears console = clear\n" +
		"ChangeName - changes your name = cName name\n" +
		"Name - prints your name = name\n" +
		"Get Stats - prints out stats of a player = stats playerName\n";
		
	}
}
