using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerEditor : EditorWindow {



	[MenuItem("Window/PlayerEditor")]
	static void Init(){
		PlayerEditor window = (PlayerEditor)EditorWindow.GetWindow (typeof(PlayerEditor));
		window.Show();
	}


}
