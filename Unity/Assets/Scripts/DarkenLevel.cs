using UnityEngine;
using System.Collections;

public class DarkenLevel : MonoBehaviour {
	public AudioSource shutSound;

	// Use this for initialization
	void Start () {
		RenderSettings.fog = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	IEnumerator lightenLater(){
		yield return new WaitForSeconds(2);
		RenderSettings.fogDensity = 0.05f;
	}
	*/

	void OnTriggerEnter(Collider ither){
		if(RenderSettings.fog)
			return;
		RenderSettings.fog = true;
		RenderSettings.fogColor = Color.black;
		RenderSettings.fogDensity = 0.10f;
		shutSound.Play();
	}
}
