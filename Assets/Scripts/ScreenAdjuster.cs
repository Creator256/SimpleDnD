using System;
using UnityEngine;

public class ScreenAdjuster : MonoBehaviour {

	public Transform allUI;

	// Use this for initialization
	void Start () {
		float asp = Camera.main.aspect;
		if(System.Math.Round(asp, 4) == 1.7778){
			allUI.localScale = new Vector3(1,1,1);
		}
		if(asp == 1.6){
			allUI.localScale = new Vector3(.9f,1,1);
		}
		if(asp == 1.5){
			allUI.localScale = new Vector3(.85f,1,1);
		}
		if(System.Math.Round(asp, 4) == 1.3333){
			allUI.localScale = new Vector3(.75f,1,1);
		}
		if(asp == 1.25){
			allUI.localScale = new Vector3(.7f,1,1);
		}
	}
	
}
