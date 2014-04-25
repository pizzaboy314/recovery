using UnityEngine;
using System.Collections;

public class switchCam : MonoBehaviour {
	public GameObject from;
	public GameObject to;
	private bool done;

	// Use this for initialization
	void Start () {
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator makeCollider(){
		yield return new WaitForSeconds(2.0f);
		collider.isTrigger = false;// make trigger invisible wall
	}

	void OnTriggerEnter(Collider other){
		if (!done){
			from.camera.enabled = false;
			to.camera.enabled = true;
			StartCoroutine(makeCollider());
		}

	}
}
