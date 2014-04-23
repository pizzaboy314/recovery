using UnityEngine;
using System.Collections;

public class handlePunch : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetHit(){
		player.SendMessage("getHit", this.transform.position);//TODO
	}
}
