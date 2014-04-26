using UnityEngine;
using System.Collections;

public class DeathCam : MonoBehaviour {

	public float lifeSpan = 4f;
	private GameObject player;
	private Camera cam;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		cam = GetComponent<Camera>();
		cam.enabled = true;
		player.GetComponent<FirstPersonController2>().enabled = false;
		player.GetComponent<MouseRotator>().enabled = false;
		player.GetComponent<FP_Shooting>().enabled = false;
		player.GetComponent<HeadBob>().enabled = false;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0){
			cam.enabled = false;
			Destroy(gameObject);
			player.GetComponent<FirstPersonController2>().enabled = true;
			player.GetComponent<MouseRotator>().enabled = true;
			player.GetComponent<FP_Shooting>().enabled = true;
			player.GetComponent<HeadBob>().enabled = true;
			Screen.showCursor = false; 
		}
	}
}
