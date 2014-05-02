using UnityEngine;
using System.Collections;

public class CharDialogHandlerLevel1 : MonoBehaviour {

	public AudioClip[] respawnQuotes;
	public AudioClip[] periodicQuotes;
	private float quoteCounter;

	// Use this for initialization
	void Start () {
		quoteCounter = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		periodicQuote();
	}

	void playClip(AudioClip clip){
		audio.clip = clip;
		audio.Play ();
	}
	void playRespawnQuote(){
		int n = Random.Range(0,respawnQuotes.Length);
		audio.clip = respawnQuotes[n];
		audio.Play();
	}
	void periodicQuote(){
		quoteCounter += Time.deltaTime;
		if (quoteCounter >= 25) {
			int n = Random.Range(0,periodicQuotes.Length);
			audio.clip = periodicQuotes[n];
			audio.Play();
			quoteCounter = 0f;
		}
	}
}
