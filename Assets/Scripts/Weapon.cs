using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Player player;
	public string weaponName;
	public string weaponClass;
	public int damage;
	public float weight;
	public int rarity;
	public int level;
	public float critChance;
	public string primaryAtt;


	void CalcStats(){
		if(primaryAtt == "strength"){
			damage = (int)(5 + level * (player.strength * .55f)); 
		}

		if (primaryAtt == "agility") {
			damage = (int)(3 + level * (player.agility * .5f));
		}

		if (primaryAtt == "intelligence") {
			damage = (int)(2 + level * (player.intelligence * .6f));
		}
	}



}
