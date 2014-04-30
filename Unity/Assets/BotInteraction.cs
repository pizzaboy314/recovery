using UnityEngine;
using System.Collections;

public class BotInteraction : MonoBehaviour {
	Animator rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shot(){
		//TODO implement HP, prevent further interation in punching
		rt.enabled = false;
	}

	private IEnumerator resetStumble(){
		yield return new WaitForSeconds(1.0f);
		rt.SetBool("PlainStumble", false);
	}

	void OnCollisionEnter(Collision other){
		if (!rt.enabled)
			return;
		if (other.gameObject.tag == "ThermalDet"){
			rt.SetBool("PlainStumble", true);
			StartCoroutine(resetStumble());
		}
	}
}
