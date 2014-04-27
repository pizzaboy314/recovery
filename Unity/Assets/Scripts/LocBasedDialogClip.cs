using UnityEngine;
using System.Collections;

public class LocBasedDialogClip : MonoBehaviour {

	public AudioClip clipToPlay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Head Camera") {
			col.gameObject.SendMessage("playClip", clipToPlay);
		}
	}
}
