using UnityEngine;
using shooting;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

	public float detsToAdd = 1f;
	public float laserToAdd = 10f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (FP_Shooting.numDets + detsToAdd <= FP_Shooting.maxDets || FP_Shooting.numLaser + laserToAdd <= FP_Shooting.maxLaser) {
			audio.Play();
		}
		player.SendMessage ("addDets", detsToAdd);
		player.SendMessage ("addLaser", laserToAdd);
	}
}
