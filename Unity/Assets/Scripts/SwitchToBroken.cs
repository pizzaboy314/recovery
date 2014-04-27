using UnityEngine;
using System.Collections;

public class SwitchToBroken : MonoBehaviour {
	public GameObject failingShip;
	public GameObject brokenShip;
	public Light spot;
	public AudioClip crash;
	private float counter;
	private bool isBroken;

	// Use this for initialization
	void Start () {
		counter = 0f;
		isBroken = false;
		failingShip.renderer.enabled = true;
		brokenShip.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter >= 4f) {
			spot.enabled = false;
		}
	}
	public void OnCollisionEnter(Collision col){
		if (isBroken == false) {
			isBroken = true;
			failingShip.renderer.enabled = false;
			brokenShip.renderer.enabled = true;
			audio.clip = crash;
			audio.Play();
		}
	}
}
