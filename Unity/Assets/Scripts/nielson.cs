using UnityEngine;
using System.Collections;

public class nielson : MonoBehaviour {

	public GameObject fireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Dead"){
			Burn();
			gameObject.tag = "Burning";
			audio.Play();
		}
	}

	void Burn(){
		Instantiate (fireEffect, transform.position, Quaternion.identity);
	}
}
