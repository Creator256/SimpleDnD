using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Player : MonoBehaviour	 {

	public string playerName;
	public int strength;
	public int agility;
	public int intelligence;
	public int vitality;
	public int luck;
	public int playerLevel;
	public float exp;

	public List<Weapon> weapons = new List<Weapon>();


	public void UpdateStat(List<string> cmdParams){
		switch (cmdParams [0]) {
			case "strength":
				strength = Convert.ToInt32 (cmdParams [1]);
				break;
			case "agility":
				agility = Convert.ToInt32 (cmdParams [1]);
				break;
			case "intelligence":
				intelligence = Convert.ToInt32 (cmdParams [1]);
				break;
			case "vitality":
				vitality = Convert.ToInt32 (cmdParams [1]);
				break;
			case "luck":
				luck = Convert.ToInt32 (cmdParams [1]);
				break;
		}
	}

	public override bool Equals(System.Object otherPlayer){
		if (otherPlayer == null) {
			return false;
		}
		Player p = otherPlayer as Player;
		if ((System.Object)p == null)
			return false;
		
		return playerName == p.playerName;
	}

	public bool Equals(Player otherPlayer){
		if ((object)otherPlayer == null) {
			return false;
		}
		return playerName == otherPlayer.playerName;
	}
}
