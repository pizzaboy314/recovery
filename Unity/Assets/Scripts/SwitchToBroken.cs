using UnityEngine;
using System.Collections;

public class SwitchToBroken : MonoBehaviour {
	public GameObject failingShip;
	public GameObject brokenShip;
	private bool isBroken;

	// Use this for initialization
	void Start () {
		isBroken = false;
		failingShip.renderer.enabled = true;
		brokenShip.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnCollisionEnter(Collision col){
		if (isBroken == false) {
			isBroken = true;
			failingShip.renderer.enabled = false;
			brokenShip.renderer.enabled = true;
		}
	}
}
