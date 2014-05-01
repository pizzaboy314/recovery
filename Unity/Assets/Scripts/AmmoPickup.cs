using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

	public float detsToAdd = 2f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		player.SendMessage ("addDets", detsToAdd);
	}
}
