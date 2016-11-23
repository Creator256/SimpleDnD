using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommandLine : MonoBehaviour {

	public RectTransform console;
	public Transform consoleCanvas;
	public Transform statsCanvas;
	public StatsMenu statsMenu;
	Text consoleOutput;
	string name;
	public InputField input;
	public Text inputText;
	public Text beforeCMDText;
	public Color textColor;

	public float outputSpeed;

	public List<Player> players;

	string outputStack;
	bool commandRunning = false;



	void OnEnable () {
		consoleOutput = console.GetComponent<Text>();

		input.onEndEdit.AddListener(x => {
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
				ParseCommand(input.text);
		});
		foreach(Text t in consoleCanvas.GetComponentsInChildren<Text>()){
			t.color = textColor;
		}

		foreach(Text t in statsCanvas.GetComponentsInChildren<Text>()){
			t.color = textColor;
		}
	}

	//All command parsing
	//and commands are found below
	void ParseCommand (string pCMD) {
		if(commandRunning){
			return;
		}
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
		commandRunning = true;
		switch (cmdVal) {
			case "print":
				if(listCMD.Count > 0)
					PrintText(listCMD);
				break;
			case "add":
				if(listCMD.Count > 0)
					Add(listCMD);
				break;
			case "subtract":
				if(listCMD.Count > 0)
					Subtract(listCMD);
				break;
			case "roll":
				if(listCMD.Count > 0)
					Roll(listCMD);
				break;
			case "textColor":
				//Doesnt need a new line because it doesnt print anything
				outputStack = "";
				if(listCMD.Count > 0)
					TextColor (listCMD);
				break;
			case "name":
				Name ();
				break;
			case "cName":
				if(listCMD.Count > 0)
					ChangeName (listCMD);
				break;
			case "newPlayer":
				if(listCMD.Count > 0)
					NewPlayer(listCMD);
				break;
			case "savePlayer":
				SavePlayer();
				break;
			case "loadPlayer":
				if(listCMD.Count > 0)
					LoadPlayer(listCMD);
				break;
			case "getStats":
				outputStack += "\n";
				Player tempGSplayer = new Player();
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
				outputStack += "\n";
				Player tempCSPlayer = new Player ();
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
			case "openStats":
				if(!statsMenu.open){
					statsMenu.OpenMenu();
					outputStack += "Console: Opening Stats Menu.\n";
				}
				else
					outputStack += "Console: Stats menu is already open.\n";
				break;
			case "closeStats":
				if(statsMenu.open){
					statsMenu.CloseMenu();
					outputStack += "Console: Closing Stats Menu.\n";
				}
				else
					outputStack += "Console: Stats menu is already closed.\n";
				break;
			case "clear":
				consoleOutput.text = " ";
				break;
			case "help":
				Help ();
				break;
			default:
				outputStack += "\n";
				outputStack += "Invalid Command!" + "\n";
				break;
		}

		StartCoroutine(PrintOutConsole());
	}

	IEnumerator PrintOutConsole(){
		if(outputStack.Length != 0){
			for(int i = 0; i < outputStack.Length; i++){
				consoleOutput.text += outputStack[i];
				yield return new WaitForSeconds(0.00001f);
			}
			outputStack = "";
			commandRunning = false;
		}
		else{
			outputStack = "";
			commandRunning = false;
		}
	}

	IEnumerator PrintOutStats(){
		
	}
		
	void PrintText(List<string> cmdParams){
		string tempText = "Console: ";
		for (int i = 0; i < cmdParams.Count; i++) {
			tempText += cmdParams[i];
			tempText += " ";
		}
		outputStack += tempText + "\n";
	}

	void Add(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a + b;
		outputStack += "Console: " + a.ToString() + " + " + b.ToString() + " = " + c.ToString() + "\n";
	}

	void Subtract(List<string> cmdParams){
		float a = Convert.ToSingle(cmdParams[0]);
		float b = Convert.ToSingle(cmdParams[1]);
		float c = a - b;
		outputStack += "Console: " + a.ToString() + " - " + b.ToString() + " = " + c.ToString() + "\n";
	}

	void Roll(List<string> cmdParams){
		int lower = 1;
		int upper = 6;
		if(cmdParams.Count != 0){
			lower = Convert.ToInt32(cmdParams[0]);
			upper = Convert.ToInt32(cmdParams[1]);
		}
		int roll = (int)(UnityEngine.Random.Range(lower, upper));

		outputStack += "Console: " + "A " + upper.ToString() + " dice rolled a " + roll.ToString() + "!" + "\n";
	}

	void TextColor (List<string> cmdParams){
		int red = Convert.ToInt32(cmdParams [0]);
		int green = Convert.ToInt32(cmdParams [1]);
		int blue = Convert.ToInt32(cmdParams [2]);
		Color newTextColor = new Color (red/255.0f, green/255.0f, blue/255.0f, 1);
//		consoleOutput.color = newTextColor;
//		inputText.color = newTextColor;
//		beforeCMDText.color = newTextColor;
//		statsMenu.strText.color = newTextColor;
//		statsMenu.agiText.color = newTextColor;
//		statsMenu.intText.color = newTextColor;
//		statsMenu.vitText.color = newTextColor;
//		statsMenu.lucText.color = newTextColor;
//		statsMenu.titleText.color = newTextColor;
//		statsMenu.playerName.color = newTextColor;
		foreach(Text t in consoleCanvas.GetComponentsInChildren<Text>()){
			t.color = newTextColor;
		}

		foreach(Text t in statsCanvas.GetComponentsInChildren<Text>()){
			t.color = newTextColor;
		}
	}

	void Name(){
		outputStack += "Console: " + "Your name is " + name + "\n";
	}

	void ChangeName(List<string> cmdParams){
		name = cmdParams [0];
		outputStack += "Console: " + "You have changed your name to " + name + "\n";
	}

	void NewPlayer(List<string> cmdParams){
		Player tempPlayer = new Player();
		tempPlayer.playerName = cmdParams[0];
		SaveLoadManager.SavePlayer(tempPlayer);
		outputStack += "Console: New Player - " + cmdParams[0] + " has been created.\n";
	}

	void SavePlayer(){
		SaveLoadManager.SavePlayer(statsMenu.player);
		outputStack += "Console: " + statsMenu.player.playerName + " has been save.\n";
	}

	void LoadPlayer(List<string> cmdParams){
		Player tempP = SaveLoadManager.LoadPlayer(cmdParams[0]);
		if (tempP.playerName == "N/A NotFound") {
			outputStack += "Console: No player with that name found.\n";
			return;
		}
		bool foundPlayer = false;
		if (players.Count > 0) {
			for (int i = 0; i < players.Count; i++) {
				if (tempP.playerName == players[i].playerName) {
					foundPlayer = true;
				}
			}
			if (!foundPlayer) {
				players.Add (tempP);
			}
		}
		else {
			players.Add (tempP);
		}
		statsMenu.player = tempP;
		outputStack += "Console: Player - " + cmdParams[0] + " has been loaded.\n";
		statsMenu.UpdateUI ();
	}

	void PrintStats(Player player){
		outputStack += "Name: " + player.playerName + "\n" +
		"Level: " + player.playerLevel + "\n" +
		"EXP: " + player.exp + "\n" +
		"Strength: " + player.strength + "\n" +
		"Agility: " + player.agility + "\n" +
		"Intelligence: " + player.intelligence + "\n" +
		"Vitality: " + player.vitality + "\n" +
		"Luck: " + player.luck + "\n";
	}

	void ChangeStats(Player player, List<string> cmdParams){
		player.UpdateStat (cmdParams);
		outputStack += cmdParams [0] + " changed to " + cmdParams [1] + "\n";
		statsMenu.UpdateUI();
	}

	void Help(){
		outputStack += "Commands Available:\n" +
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
