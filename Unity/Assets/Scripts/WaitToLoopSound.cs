using UnityEngine;
using System.Collections;

public class WaitToLoopSound : MonoBehaviour {

	public float secondsToWait;
	private bool counting;

	// Use this for initialization
	void Start () {
		counting = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (counting == true) {
			secondsToWait -= Time.deltaTime;
			if(secondsToWait <= 0f){
				counting = false;
				audio.Play();
			}
		}
	}
}
