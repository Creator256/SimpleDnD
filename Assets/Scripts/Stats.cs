using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public int strength;
	public int agility;
	public int intelligence;
	public int vitality;
	public int luck;

	public Stats(int str, int agi, int intel, int vit, int lu){
		strength = str;
		agility = agi;
		intelligence = intel;
		vitality = vit;
		luck = lu;
	}

	public void assignStats(Stats rhs){
		strength += rhs.strength;
		agility += rhs.agility;
		intelligence += rhs.intelligence;
		vitality += rhs.vitality;
		luck += rhs.luck;
		Destroy (rhs);
	}
}

