using UnityEngine;
using System.Collections;

public class BotInteraction : MonoBehaviour {
	public int hitPoint;
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
		if (hitPoint < 0)
			rt.enabled = false;
		else --hitPoint;
	}

	private IEnumerator resetStumble(){
		yield return new WaitForSeconds(0.4f);
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
