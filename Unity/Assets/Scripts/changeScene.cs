using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI(){
		if(GUI.Button(new Rect(400, 650, 200, 40), "Start"))
			Application.LoadLevel("level1");
	}
	                  
}
