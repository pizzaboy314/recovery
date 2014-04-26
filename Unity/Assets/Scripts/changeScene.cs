using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
	private int lastW, lastH;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (lastW != Screen.width || lastH != Screen.height){
			guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
			lastH = Screen.height;
			lastW = Screen.width;
		}
	}

	private void OnGUI(){
		int x = Screen.width / 2 - 400/2;
		int y = Screen.height * 3 / 4 - 200/2;
		if(GUI.Button(new Rect(x, y, 200, 40), "Start"))
			Application.LoadLevel("intro");
	}
	                  
}
