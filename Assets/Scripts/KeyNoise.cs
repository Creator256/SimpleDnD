using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNoise : MonoBehaviour {

	public AudioSource noise;

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			noise.Play ();
		}
	}
}
