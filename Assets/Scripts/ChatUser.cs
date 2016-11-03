using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class ChatUser : NetworkBehaviour {

	string userName;
	Transform chatPrefab;
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
	}

	void SendMessage(string message){
	}


}
