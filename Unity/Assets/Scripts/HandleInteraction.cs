using UnityEngine;
using System.Collections;

public class HandleInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getHit(Vector3 from){
		//Player got hit
		this.rigidbody.AddForce((this.transform.position - from) * 1000);
		//Debug.Log("YA GOT HIT");
	}
}
