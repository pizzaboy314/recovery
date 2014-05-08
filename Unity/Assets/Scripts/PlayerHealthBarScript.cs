using UnityEngine;
using shooting;
using System.Collections;

public class PlayerHealthBarScript : MonoBehaviour {

	public GUIStyle progress_empty;
	public GUIStyle progress_full;
	public Font digital;
	
	//current progress
	public float barDisplay;
	
	Vector2 pos = new Vector2 (Screen.width - 260f, Screen.height - 60f);
	Vector2 size = new Vector2(250,50);
	
	public Texture2D emptyTex;
	public Texture2D fullTex;
	private Texture2D emptyTexTMP;
	private Texture2D fullTexTMP;

	private bool showGUI = true;
	private string healthtext = "HEALTH";
	private string healthval = "";
	private string dettext = "GRENADES";
	private string detammo = "";
	private string lasertext = "AMMO";
	private string laserammo = "";
	
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

		//GUIStyle style = new GUIStyle(); //TODO find a way to make text white
		//style.font = digital;
		//style.fontSize = 16;
		//style.fontStyle = FontStyle.Bold;

		healthval = (showGUI == true) ? "" + HandleInteraction.currHealth : "";
		GUI.Label (new Rect(pos.x, pos.y-20, size.x, size.y), healthtext);
		GUI.Label (new Rect(pos.x+5, pos.y+15, size.x, size.y), healthval);

		detammo = (showGUI == true) ? "" + FP_Shooting.numDets : "";
		GUI.Label (new Rect(2*(Screen.width/3)-60, pos.y-20, size.x, size.y), dettext);
		GUI.Label (new Rect(2*(Screen.width/3)-60, pos.y+15, size.x, size.y), detammo);

		laserammo = (showGUI == true) ? "" + FP_Shooting.numLaser : "";
		GUI.Label (new Rect(2*(Screen.width/3)-160, pos.y-20, size.x, size.y), lasertext);
		GUI.Label (new Rect(2*(Screen.width/3)-160, pos.y+15, size.x, size.y), laserammo);
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
			healthtext = "";
			dettext = "";
			lasertext = "";
		} else {
			showGUI = true;
			emptyTex = emptyTexTMP;
			fullTex = fullTexTMP;
			emptyTexTMP = null;
			fullTexTMP = null;
			healthtext = "HEALTH";
			dettext = "GRENADES";
			lasertext = "AMMO";
		}
	}

}
