using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatsMenu : MonoBehaviour {

	public Button strButton;
	public Button agiButton;
	public Button intButton;
	public Button vitButton;
	public Button lucButton;

	public ScriptablePlayer player;


	// Use this for initialization
	void Start () {
		strButton.onClick.AddListener (() => incStrength ());
		agiButton.onClick.AddListener (() => incAgility ());
		intButton.onClick.AddListener (() => incIntelligence ());
		vitButton.onClick.AddListener (() => incVitality ());
		lucButton.onClick.AddListener (() => incLuck ());

	}
	

	void incStrength(){
		player.strength++;
	}

	void incAgility(){
		player.agility++;
	}

	void incIntelligence(){
		player.intelligence++;
	}
	void incVitality(){
		player.vitality++;
	}
	void incLuck(){
		player.luck++;
	}


}
