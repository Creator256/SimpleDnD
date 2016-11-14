using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player", order = 1)]
[Serializable]
public class ScriptablePlayer : ScriptableObject	 {

	public string playerName;
	public int strength;
	public int agility;
	public int intelligence;
	public int vitality;
	public int luck;
	public int playerLevel;
	public float exp;

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
}
