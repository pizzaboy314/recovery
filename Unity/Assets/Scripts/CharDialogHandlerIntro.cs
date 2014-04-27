using UnityEngine;
using System.Collections;

public class CharDialogHandlerIntro : MonoBehaviour {

	public AudioClip endOfThatShip;

	// Use this for initialization
	void Start () {
		audio.clip = endOfThatShip;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playClip(AudioClip clip){
		audio.clip = clip;
		audio.Play ();
	}
}
