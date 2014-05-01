﻿using UnityEngine;
using System.Collections;

public class PlayerHealthBarScript : MonoBehaviour {

	public GUIStyle progress_empty;
	public GUIStyle progress_full;
	
	//current progress
	public float barDisplay;
	
	Vector2 pos = new Vector2 (Screen.width - 260f, Screen.height - 60f);
	Vector2 size = new Vector2(250,50);
	
	public Texture2D emptyTex;
	public Texture2D fullTex;
	private Texture2D emptyTexTMP;
	private Texture2D fullTexTMP;

	private bool showGUI = true;
	
	void OnGUI()
	{
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), emptyTex, progress_empty);
		
		GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), fullTex, progress_full);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
		
		GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
		
		GUI.EndGroup();
		GUI.EndGroup();
	}
	
	void Update()
	{
		
		//the player's health
		barDisplay = HandleInteraction.currHealth/HandleInteraction.maxHealth;
	}
	public void toggleGUI(){
		if (showGUI == true) {
			showGUI = false;
			emptyTexTMP = emptyTex;
			fullTexTMP = fullTex;
			emptyTex = null;
			fullTex = null;
		} else {
			showGUI = true;
			emptyTex = emptyTexTMP;
			fullTex = fullTexTMP;
			emptyTexTMP = null;
			fullTexTMP = null;
		}
	}

}
