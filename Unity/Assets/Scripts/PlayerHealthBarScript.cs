using UnityEngine;
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
	private string healthtext = "HEALTH";
	private string healthval = "";
	private string ammotext = "GRENADES";
	private string ammoval = "";
	
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

		healthval = (showGUI == true) ? "" + HandleInteraction.currHealth : "";
		GUI.Label (new Rect(pos.x, pos.y-20, size.x, size.y), healthtext);
		GUI.Label (new Rect(pos.x+5, pos.y+15, size.x, size.y), healthval);

		ammoval = (showGUI == true) ? "" + FP_Shooting.numDets : "";
		GUI.Label (new Rect(2*(Screen.width/3)-20, pos.y-20, size.x, size.y), ammotext);
		GUI.Label (new Rect(2*(Screen.width/3)-20, pos.y+15, size.x, size.y), ammoval);
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
			ammotext = "";
		} else {
			showGUI = true;
			emptyTex = emptyTexTMP;
			fullTex = fullTexTMP;
			emptyTexTMP = null;
			fullTexTMP = null;
			healthtext = "HEALTH";
			ammotext = "GRENADES";
		}
	}

}
