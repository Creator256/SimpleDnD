using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatsMenu : MonoBehaviour {
	[Header("Main Stats Menu")]
	public Transform statsMenu;
	public Text titleText;

	[Header("Button Vars")]
	public Button strButton;
	public Button agiButton;
	public Button intButton;
	public Button vitButton;
	public Button lucButton;

	[Header("Text Vars")]
	public Text strText;
	public Text agiText;
	public Text intText;
	public Text vitText;
	public Text lucText;

	//[Header("Test Player")]
	public Player player;

	[Header("Other Vars")]
	public bool open;
	public Animator anims;


	// Use this for initialization
	void Start () {
		player = new Player();
		strButton.onClick.AddListener (() => incStrength ());
		agiButton.onClick.AddListener (() => incAgility ());
		intButton.onClick.AddListener (() => incIntelligence ());
		vitButton.onClick.AddListener (() => incVitality ());
		lucButton.onClick.AddListener (() => incLuck ());

		strText.text = "Strength: " + player.strength;
		agiText.text = "Agility: " + player.agility;
		intText.text = "Intelligence: " + player.intelligence;
		vitText.text = "Vitality: " + player.vitality;
		lucText.text = "Luck: " + player.luck;
	}
	

	void incStrength(){
		player.strength++;
		strText.text = "Strength: " + player.strength;

	}

	void incAgility(){
		player.agility++;
		agiText.text = "Agility: " + player.agility;

	}

	void incIntelligence(){
		player.intelligence++;
		intText.text = "Intelligence: " + player.intelligence;

	}
	void incVitality(){
		player.vitality++;
		vitText.text = "Vitality: " + player.vitality;

	}
	void incLuck(){
		player.luck++;
		lucText.text = "Luck: " + player.luck;

	}

	public void UpdateUI(){
		strText.text = "Strength: " + player.strength;
		agiText.text = "Agility: " + player.agility;
		intText.text = "Intelligence: " + player.intelligence;
		vitText.text = "Vitality: " + player.vitality;
		lucText.text = "Luck: " + player.luck;

	}


	public void OpenMenu(){
		anims.SetTrigger("SlideIn");
		UpdateUI();
		open = true;
	}

	public void CloseMenu(){
		anims.SetTrigger("SlideOut");
		open = false;
	}


}
