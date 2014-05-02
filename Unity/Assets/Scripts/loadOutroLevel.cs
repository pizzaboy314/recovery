using UnityEngine;
using System.Collections;

public class loadOutroLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Player") {
			Camera.main.enabled = false;
			Application.LoadLevel("outro");
		}
	}
}
