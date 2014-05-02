using UnityEngine;
using System.Collections;

public class LocBasedDialogClip : MonoBehaviour {

	public AudioClip clipToPlay;
	public GameObject toDestroy = null;
	public bool playOnce = false;
	private bool hasPlayed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Head Camera") {
			if(!(playOnce == true && hasPlayed == true)){
				col.gameObject.SendMessage("playClip", clipToPlay);
				if(toDestroy != null){
					Destroy(toDestroy);
				}
			}
			if(hasPlayed == false){
				hasPlayed = true;
			}
		}
	}
}
