using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoadManager {


	public static void SavePlayer(Player p){
		string saveString = JsonUtility.ToJson (p, true);
		string path = Application.dataPath + "/Saves/" + p.playerName + ".json";
		File.WriteAllText (path, saveString);
		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh ();
		#endif
	}
		
	public static Player LoadPlayer(string pName){
		Player temp = new Player();
		string path = Application.dataPath + "/Saves/" + pName + ".json";
		string jString = File.ReadAllText(path);
		JsonUtility.FromJsonOverwrite(jString, temp);
		return temp;
	}


}
