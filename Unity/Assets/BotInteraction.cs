using UnityEngine;
using System.Collections;

public class BotInteraction : MonoBehaviour {
	Animator rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shot(){
		//TODO implement HP, prevent further interation in punching
		rt.enabled = false;
	}
}
