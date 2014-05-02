using UnityEngine;
using System.Collections;

public class safetyNet : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject == player){
			player.SendMessage("reset");
		}
	}
}
