﻿using UnityEngine;
using System.Collections;

public class CharDialogHandlerOutro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void playClip(AudioClip clip){
		audio.clip = clip;
		audio.Play ();
	}
}
