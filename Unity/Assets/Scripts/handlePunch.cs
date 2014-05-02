using UnityEngine;
using System.Collections;

public class handlePunch : MonoBehaviour {
	public GameObject player;
	public GameObject rightHand;
	public AudioClip[] punches;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetHit(){
		player.SendMessage("getHit", this.transform.position);//TODO
		int n = Random.Range(0,punches.Length);
		rightHand.audio.clip = punches[n];
		rightHand.audio.Play();
	}
}
