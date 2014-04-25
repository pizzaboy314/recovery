using UnityEngine;
using System.Collections;

public class WaitSecondsAfterCamEnable : MonoBehaviour {

	public float timeCutScene;
	public GameObject player;
	public Camera camToDisable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCutScene < 0.0f){
			player.SetActive(true);
			camToDisable.enabled = false;
		}
		else if (camToDisable.enabled)
			timeCutScene -= Time.deltaTime;
	}
}
